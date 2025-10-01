# Bibliotekssystem – C# Laboration

##  Beskrivning
Ett konsolbaserat bibliotekssystem med två roller: bibliotekarie och låntagare. Stödjer lån, återlämning, sökning och persistens via JSON-fil.

##  Så här kör man
1. Öppna terminalen i projektmappen
2. Kör: `dotnet run`

##  Teknisk design
- **Abstrakt klass**: `User` med abstrakt metod `ShowMenu()`
- **Interface**: `ISearchable` för sökfunktionalitet
- **Arv**: `Librarian` och `Borrower` ärver från `User`
- **Datatyper**: `string`, `bool`, `List<Book>`
- **Kontrollstrukturer**: `if/else`, `switch`, `foreach`
- **Persistens**: Böcker sparas/laddas från `books.json`
- **Validering**: Unikt ISBN, utlånad-status

##  Copilot-reflektion
Två metoder (`Search`, `BorrowBook`) genererades med Copilot.  
**Fördelar**: Snabb kodgenerering, minskar boilerplate.  
**Nackdelar**: Kräver noggrann granskning – Copilot kan anta fel kontext eller missa validering.
