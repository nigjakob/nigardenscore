# nigardenscore
Automatisch Schaugärten mit Contao-Umfrageergebnissen bewerten.

# Voraussetzungen

Um das Programm ausführen zu können ist [.NET Framework 4.8.1](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net481-offline-installer) notwendig.

# Installation

Alle veröffentlichten Versionen der Anwendung können unter [Releases](https://github.com/nigjakob/nigardenscore/releases) gefunden werden. Das Archiv muss extrahiert und die .exe-Datei ausgeführt werden.

# Verwendung

1. Durch Klick auf den "Schaugarten hinzufügen"-Knopf, werden alle Schaugärten, die ausgewertet werden sollen, ausgewählt. Diese Dateien sollten sich im Contao-Umfrage-Format befinden.

> Die "Datei"-Spalte zeigt den Namen der Seite in der Excel-Tabelle an (die Zeichenfolge wird in der eigentlichen Tabelle auf 31 Zeichen getrimmt).
Die "Pfad"-Spalte zeigt den eben gewählten Dateipfad an.

2. In der Tabelle unter dem "Schaugarten hinzufügen"-Knopf, werden die verschiedenen Antwortmöglichkeiten, ihre zugehörige Punktzahl und ob diese Antwortmöglichkeiten in die Bewertung eingehen, festgelegt.

> Es ist wichtig, dass die Zahl unter "Punktezahl" eine ganze Zahl ist (z. B. sind -10, -2, 0, 1, 45, etc. valide Eingaben) und keine Dezimalzahl.

3. Sobald alle möglichen Antwortmöglichkeiten erstellt worden sind, drückt man auf "Gesamttabelle erstellen" und eine .xlsx-Datei wird im Dateipfad, in dem das Programm ausgeführt worden ist, erstellt.

## Hinweis

Es ist zu beachten, dass die ersten 31 Zeichen (aufgrund einer Excelzeichenbeschränkung) für alle Ergebnisse eindeutig sind:

**Falsch:**

* Schaugartenbewertungen Umfrageergebnis 2023 - Schloss A.xlsx
* Schaugartenbewertungen Umfrageergebnis 2023 - Schloss B.xlsx

**Richtig:**

* Schloss A - Schaugartenbewertungen Umfrageergebnis 2023.xlsx
* Schloss B - Schaugartenbewertungen Umfrageergebnis 2023.xlsx

# Tabellenformat

In der generierten Excel-Tabelle befindet sich eine Seite, die eine Zusammenfassung enthält (Schaugartenname - zugehörige Punktezahl) und dann nach der Reihe die detailierten Ergebnisse für einzelne Schaugärten.
