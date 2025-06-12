# MindLedger

MindLedger ist eine Desktop-Anwendung zur Verwaltung von Notizen. Ziel ist es, eine klar strukturierte, lokal gespeicherte Anwendung zu entwickeln, die moderne Softwarearchitektur mit einem benutzerfreundlichen Design verbindet. Das Projekt wird mit .NET 9, WPF und SQLite umgesetzt und orientiert sich an Clean Architecture und dem MVVM-Pattern.

## Aktueller Stand

Das Projekt befindet sich noch im Aufbau. Die grundlegende Struktur steht bereits: Solution-Setup, Projektaufteilung, erste Dienste und die Einbindung von Dependency Injection wurden umgesetzt. Die konkrete Anwendungslogik und Benutzeroberfläche werden schrittweise entwickelt.

## Projektstruktur

- `MindLedger.App`: WPF-Anwendung mit Einstiegspunkt und UI
- `MindLedger.AppLogic`: Anwendungsschicht mit Services und ViewModels
- `MindLedger.Domain`: Zentrale Domänenklassen und Interfaces
- `MindLedger.Infrastructure`: (Geplant) Datenzugriff mit SQLite über Entity Framework Core

## Was bisher umgesetzt wurde

- Einrichtung der Projektmappe mit sauberer Trennung der Schichten
- Anbindung von Dependency Injection mittels `Microsoft.Extensions.Hosting`
- MVVM-Basiskonzept im Frontend
- Vorbereitung für die Implementierung der Datenpersistenz

## Geplante Funktionen

- Erstellen, Bearbeiten und Löschen von Notizen (CRUD)
- Zuordnung von Kategorien oder Tags
- Filter- und Suchfunktion
- Umschaltbarer Dark-/Light-Mode
- Asynchrone Datenzugriffe für bessere Reaktionsfähigkeit
- Lokale Speicherung mit SQLite

## Verwendete Technologien

- .NET 9
- WPF (Windows Presentation Foundation)
- Entity Framework Core
- SQLite
- MVVM
- Clean Architecture
- Dependency Injection

## Lizenz

MIT – siehe [LICENSE](./LICENSE)
