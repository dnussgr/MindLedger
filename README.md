# MindLedger

**MindLedger** ist eine strukturierte Notiz- und Kampagnenverwaltungs-App für **Dungeon Master** (D&D 5e oder andere TTRPGs). Die Anwendung wird mit **.NET 9**, **WPF**, **Entity Framework Core** und **WPF UI** entwickelt und kombiniert moderne Softwarearchitektur mit einem Interface, das speziell auf die Bedürfnisse von Spielleitern zugeschnitten ist.

## Ziel
MindLedger soll mehr sein als eine einfache Notiz-App: Es soll DMs ermöglichen, **ihre Welt strukturiert aufzubauen**, **Sitzungen effizient zu planen** und **alle Elemente einer Kampagne in einer zentralen, lokal gespeicherten Anwendung zu verwalten** – ohne Abhängigkeit von Online-Plattformen.
Warum nicht einfach Obsidian, Notion, WorldAnvil oder OneNote?
Obsidian und Notion sind sehr komplexe Tools und haben oft eine steile Lernkurve, WorldAnvil ist zwar spezialisiert, hat aber ein Abo-Modell.

**Viele Spielleiter verwenden OneNote für ihre Kampagnen – warum also MindLedger?**

OneNote ist flexibel, aber nicht spezialisiert. Es bietet keine Unterscheidung zwischen verschiedenen Notiztypen (z. B. Session, NPC, Ort), keine logischen Verknüpfungen zwischen Einträgen und keine durchsuchbaren Tags mit semantischer Bedeutung.

MindLedger ist für Spielleiter konzipiert, die mehr Struktur wollen – ohne Komplexität.
Ein paar zentrale Unterschiede:

| Feature                         | OneNote                 | MindLedger                                     |
| ------------------------------- | ----------------------- | ---------------------------------------------- |
| Strukturierung nach Typen       | manuell über Seiten     | fest definierte Entitäten (z. B. Session, NPC) |
| Zugehörigkeit zu Kampagnen      | manuell über Abschnitte | logisch abgebildet über Datenmodell            |
| Tagging                         | rudimentär, keine Suche | durchsuchbar, filterbar, mehrfach nutzbar      |
| Sessions automatisch nummeriert | nein                    | ja                                             |
| Markdown-Unterstützung          | nein                    | geplant integriert + Export                    |
| Export (zB nach Obsidian, Homebewery)       | nicht sinnvoll möglich  | `.md`-Export vorbereitet                       |
| Speicherort                     | primär OneDrive         | vollständig lokal, SQLite-basiert              |

## Projektstatus

Das Projekt befindet sich in der aktiven Entwicklung. Die grundlegende Architektur ist bereits implementiert:

- Kernarchitektur: Clean Architecture, DI, EF Core, SQLite  
- `NoteBase`-Vererbung mit Ableitungen (Session, Character ...)  
- Tagging-Infrastruktur inkl. Repository & SQLite-Tests  
- WPF UI-Grundgerüst + Themeinitialisierung

---

## In Arbeit

- Text-Editor inkl. Export  
- Multitagging beim Notizerstellen  
- Such- und Filterfeature

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
- UI - Grundsätzliches Design vorhanden, bis auf Editor noch keine Funktion

---

## Nächste Schritte

- [ ] Kampagnen-Dropdown & Kontextwechsel - Funktion  
- [ ] Accordion-Navigation (Sessions, NPCs…) - Funktion  
- [ ] Tag-Auswahl & Erstellung im Editor  
- [ ] Markdown-Preview & `.md` Export  
- [ ] Suche, Sortierung & Filterung - Funktion

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
