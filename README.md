# MindLedger

**MindLedger** ist eine moderne, lokal laufende Notizverwaltung für Windows, entwickelt mit **.NET 9**, **WPF** und **SQLite**. Ziel des Projekts ist es, eine wartbare, asynchrone Anwendung auf Basis von Clean Architecture und MVVM bereitzustellen – mit Fokus auf ein durchdachtes UI/UX, das WPF UI (lepo.co) verwendet.

## Projektstatus

Das Projekt befindet sich in der aktiven Entwicklung. Die grundlegende Architektur ist bereits implementiert:

- Clean Architecture mit klarer Trennung von UI, Logik und Datenzugriff
- Setup für Dependency Injection und Entity Framework Core
- Erste ViewModels, Services und Datenbankzugriff mit SQLite
- Integration des UI-Toolkits [WPF UI](https://wpfui.lepo.co/) (Theming, Controls)

---

## Projektstruktur

- `MindLedger.App`: WPF UI-Projekt (UI, Theme, Einstiegspunkt)
- `MindLedger.AppLogic`: Anwendungsschicht mit Services und ViewModels
- `MindLedger.Domain`: Domänenschicht (Note-Entität, Interfaces)
- `MindLedger.Infrastructure`: Infrastruktur (EF Core, SQLite)
- `MindLedger.Tests`: Unit-Tests

## Was bisher umgesetzt wurde

- Projektstruktur und Solution-Setup
- Dependency Injection mit `Microsoft.Extensions.Hosting`
- EF Core + SQLite
- ViewModel-Basis mit `CommunityToolkit.Mvvm`
- Theme-Setup über WPF-UI
- Startup über Dependency Injection

## Geplante Funktionen

- Erstellen, Bearbeiten und Löschen von Notizen (CRUD)
- Zuordnung von Kategorien oder Tags
- Filter- und Suchfunktion
- Umschaltbarer Dark-/Light-Mode
- Asynchrone Datenzugriffe für bessere Reaktionsfähigkeit

## Verwendete Technologien

- [.NET 9](https://github.com/dotnet/core)
- [WPF](https://learn.microsoft.com/dotnet/desktop/wpf/)
- [WPF UI](https://wpfui.lepo.co/)
- [SQLite](https://www.sqlite.org/index.html)
- [Entity Framework Core](https://learn.microsoft.com/ef/)
- [MVVM Toolkit](https://learn.microsoft.com/dotnet/communitytoolkit/mvvm/)
- Clean Architecture
- Dependency Injection

## Lizenz

MIT – siehe [LICENSE](./LICENSE)
