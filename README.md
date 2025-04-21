# Отчёт
## Введение
Проект **ASP.NET Core Web API** для автоматизации ключевых процессов Московского зоопарка:
1) Планирование, изменение и отметка кормлений
2) Сбор статистики (кол‑во животных, свободные места)
3) CRUD‑операции над животными и вольерами
4) Перемещение животных между вольерами

Архитектура выстроена по Clean Architecture и опирается на Domain‑Driven Design. Проект разделён на четыре слоя:
1. **Domain** (ядро)
2. **Application/UseCases** (сервисы, DTO, обработчики событий)
3. **Infrastructure/Persistence** (in‑memory репозитории)
4. **Presentation/WebApi** (контроллеры, ViewModels, Swagger)

---

## 1. Функционал:

| Use Case                                                    | Файлы / модули                                                                                                                                                 |
|-------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **a. Добавить / удалить животное**                          | • `WebApi/Controllers/AnimalsController.cs`<br>• `UseCases/Services/DeleteAnimalService.cs`<br>• `Core/Models/Animal.cs`                                       |
| **b. Добавить / удалить вольер**                            | • `WebApi/Controllers/EnclosuresController.cs`<br>• `UseCases/Services/RemoveEnclosureService.cs` <br>• `Core/Models/Enclosure.cs`    |
| **c. Переместить животное между вольерами**                 | • `AnimalsController.Transfer(...)`<br>• `UseCases/Services/AnimalTransferService.cs`<br>• событие `Core/Events/AnimalMovedEvent.cs`<br>• `Core/Models/Animal.cs` |
| **d. Просмотреть расписание кормления**                     | • `WebApi/Controllers/FeedingSchedulesController.cs` (GET)<br>• `Core/Models/FeedingSchedule.cs`                                                                |
| **e. Добавить новое кормление в расписание**                | • `FeedingSchedulesController.Create(...)`<br>• `UseCases/Services/FeedingManager.cs`<br>• событие `Core/Events/FeedingTimeEvent.cs`                             |
| **f. Просмотреть статистику зоопарка**                      | • `WebApi/Controllers/ZooStatisticsController.cs`<br>• `UseCases/Services/ZooStatisticsProvider.cs`                                                            |
| **g. Доп операции**                                 | • `FeedingSchedule.MarkAsDone()` для отметки кормления<br>• `Enclosure.Clean()` + событие `EnclosureCleanedEvent`                                              |

---

## 2. Примененные концепции DDD:

- **Value Objects**
  • `Core/VO/Name.cs`, `BirthDate.cs`, `Capacity.cs`, `Size.cs` — валидация примитивов в конструкторах.
- **Entities**
  • `Core/Models/Animal.cs`, `Enclosure.cs`, `FeedingSchedule.cs` — инкапсулируют состояние и поведение (методы `Feed()`, `Treat()`, `MoveTo()`, `AddAnimal()`, `Clean()`, `Reschedule()`, `MarkAsDone()`).
- **Domain Events**
  • `Core/Events/AnimalMovedEvent.cs`, `FeedingTimeEvent.cs`, `EnclosureCleanedEvent.cs` — генерируются внутри моделей и обрабатываются подписчиками.
- **Доменные обработчики**
  • `UseCases/EventHandlers/AnimalMovedEventHandler.cs`, `FeedingTimeEventHandler.cs`, `EnclosureCleanedEventHandler.cs` — подписываются на шину `DomainEvents` и выводят логи или инициируют побочные действия.

---

## 3. Принципы Clean Architecture

1. **Абстракции через интерфейсы**
   - `Core/Ports/IAnimalRepository.cs`, `IEnclosureRepository.cs`, `IFeedingScheduleRepository.cs`
   - `UseCases/Contracts/IAnimalTransferService.cs`, `IFeedingManager.cs`, `IZooStatisticsProvider.cs`
2. **Направление зависимостей**
   - Presentation → Application → Domain
   - Infrastructure → Domain
   - Ядро не зависит от внешних слоёв.
3. **Изоляция бизнес‑логики**
   - Вся бизнес‑логика находится в `Core` и `UseCases`, контроллеры маршрутизируют HTTP.
4. **Dependency Injection**
   - В `Program.cs` регистрируются интерфейсы и реализации (`AddSingleton<…>`, `AddScoped<…>`), нет прямых ссылок на конкретные классы в моделях.
5. **Тестируемость**
   - Unit‑тесты покрывают ключевые сценарии, степень покрытия 70+%.
