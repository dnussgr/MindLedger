# MindLedger

**MindLedger** ist eine strukturierte Notiz- und Kampagnenverwaltungs-App für **Dungeon Master** (D&D 5e oder andere TTRPGs). Die Anwendung wird mit **.NET 9**, **WPF**, **Entity Framework Core** und **WPF UI** entwickelt und kombiniert moderne Softwarearchitektur mit einem Interface, das speziell auf die Bedürfnisse von Spielleitern zugeschnitten ist.

## Ziel
MindLedger soll mehr sein als eine einfache Notiz-App: Es soll DMs ermöglichen, **ihre Welt strukturiert aufzubauen**, **Sitzungen effizient zu planen** und **alle Elemente einer Kampagne in einer zentralen, lokal gespeicherten Anwendung zu verwalten** – ohne Abhängigkeit von Online-Plattformen.

## Projektstatus

Das Projekt befindet sich in der aktiven Entwicklung. Die grundlegende Architektur ist bereits implementiert:

- Clean Architecture mit klarer Trennung von UI, Logik und Datenzugriff
- Setup für Dependency Injection und Entity Framework Core
- Erste ViewModels, Services und Datenbankzugriff mit SQLite
- Integration des UI-Toolkits [WPF UI](https://wpfui.lepo.co/) (Theming, Controls)

---

## Geplante Funktionen

- **Kampagnenstruktur mit Tiefe**  
  Kampagne → Sessions, Orte, Charaktere, NPCs, Worldbuilding, Tags

- **Markdown-Editor mit Export**  
  - Bearbeitung direkt im Editor
  - Export als `.md`-Datei (z. B. für Obsidian oder Git-Repos)

- **Tag-System**  
  - Beliebig viele Tags pro Eintrag
  - Filter- und Suchfunktion über Titel, Inhalt, Tags

- **Dark-/Light-Mode & modernes UI**  
  - Styling durch [WPF UI](https://wpfui.lepo.co/)
  - Fokus auf Lesbarkeit und minimalistische Navigation

- **Dateianhänge (optional)**  
  - Bilder, Karten, Handouts direkt an Notizen anhängen

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

---

## Nächste Schritte

- UI: Navigationsstruktur nach Kampagnenbaum
- CRUD-Oberfläche für Sessions, Charaktere, NPCs etc.
- Markdown-Editor mit Exportfunktion
- Tagging- und Filterlogik
- Synchronisierbare lokale Datenbankstruktur

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
