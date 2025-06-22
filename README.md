# MindLedger

**MindLedger** ist eine strukturierte Notiz- und Kampagnenverwaltungs-App für **Dungeon Master** (D&D 5e oder andere TTRPGs). Die Anwendung wird mit **.NET 9**, **WPF**, **Entity Framework Core** und **WPF UI** entwickelt und kombiniert moderne Softwarearchitektur mit einem Interface, das speziell auf die Bedürfnisse von Spielleitern zugeschnitten ist.

## Ziel
MindLedger soll mehr sein als eine klassische Notiz-App: Es ermöglicht DMs, **ihre Welt systematisch aufzubauen**, **Sitzungen effizient zu planen** und **alle Elemente einer Kampagne zentral und lokal zu verwalten** – ganz ohne Cloud-Abhängigkeit.

### Warum nicht Obsidian, Notion, WorldAnvil – oder OneNote?

- **Obsidian / Notion**: Sehr leistungsfähig, aber oft überladen und komplex.
- **WorldAnvil**: Speziell für TTRPG, aber im vollen Umfang kostenpflichtig.
- **OneNote**: Flexibel, aber generisch – keine Kampagnenlogik, kein semantisches Tagging, keine strukturierten Notiztypen.

### Warum **MindLedger** statt OneNote?

| Feature                         | OneNote                 | MindLedger                                     |
| ------------------------------- | ----------------------- | ---------------------------------------------- |
| Strukturierung nach Typen       | manuell über Seiten     | fest definierte Entitäten (z. B. Session, NPC) |
| Zugehörigkeit zu Kampagnen      | manuell über Abschnitte | logisch abgebildet über Datenmodell            |
| Tagging                         | rudimentär, keine Suche | durchsuchbar, filterbar, mehrfach nutzbar      |
| Sessions automatisch nummeriert | nein                    | ja                                             |
| Markdown-Unterstützung          | nein                    | geplant integriert + Export                    |
| Export (zB nach Obsidian, Homebewery)       | nicht sinnvoll möglich  | `.md`-Export vorbereitet                       |
| Speicherort                     | primär OneDrive         | vollständig lokal, SQLite-basiert              |

MindLedger richtet sich an Spielleiter, die **mehr Struktur wollen – ohne zusätzliche Komplexität.**

## Projektstatus

Das Projekt befindet sich in der aktiven Entwicklung. Die grundlegende Architektur ist bereits implementiert:

- Clean Architecture mit klarer Trennung von UI, Logik, Daten
- `NoteBase`-Vererbung für verschiedene Notiztypen
- Tagging mit Repository + EF Core Anbindung
- UI-Grundgerüst mit WPF UI Theme

---

## In Arbeit

- Texteditor inkl. Markdown-Export  
- Tagging (Mehrfachauswahl beim Erstellen)  
- Suche & Filterung nach Tags, Titel, Inhalt 

---
 
## Projektstruktur

- `MindLedger.App`: WPF-Oberfläche, Einstiegspunkt, Theme
- `MindLedger.AppLogic`: ViewModels, Services, State Management
- `MindLedger.Domain`: Entitäten und Schnittstellen
- `MindLedger.Infrastructure`: EF Core, Datenbankzugriff
- `MindLedger.Tests`: Unit-Tests

## Was bisher umgesetzt wurde

- Projektstruktur, Solution Setup
- Dependency Injection über `Microsoft.Extensions.Hosting`
- EF Core + SQLite + Migrations
- ViewModels mit `CommunityToolkit.Mvvm`
- Theme-Integration mit WPF UI
- UI-Layout & Navigation ohne Editorlogik

---

## Nächste Schritte

- [ ] Kampagnen-Dropdown mit Kontextwechsel  
- [ ] Accordion-Navigation (Sessions, NPCs etc.)  
- [ ] Tag-Auswahl & Erstellung in Notizen  
- [ ] Markdown-Editor & Exportfunktion  
- [ ] Suche, Sortierung & Filterung

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
