# Food Around The Globe (FATG) - Project Opzet & Ontwikkelgids

**Welkom bij het FATG Team!** Deze gids is ons startpunt voor het project. Ons doel is om jou stap-voor-stap te begeleiden bij het opzetten van je ontwikkelomgeving, het begrijpen van onze workflow en het starten met code. We gaan ervan uit dat we nog niet veel ervaring hebben, dus we leggen alles zo duidelijk mogelijk uit.

Neem deze gids zorgvuldig door en voer alle stappen uit. Als je ergens vastloopt, noteer dan precies wat er misging (inclusief foutmeldingen) en vraag hulp. Samen zorgen we ervoor dat iedereen een vliegende start maakt!

---

## Inhoudsopgave

1.  [Project Overzicht](#1-project-overzicht)
    *   1.1. Wat is FATG?
    *   1.2. Onze Technologie Stack
    *   1.3. Ons Team & Onze Rollen
2.  [Voorbereiding: Essentiële Software Installeren](#2-voorbereiding-essentiële-software-installeren)
    *   2.1. Visual Studio Code (VS Code)
    *   2.2. Node.js & npm
    *   2.3. Git
    *   2.4. PostgreSQL Database
    *   2.5. Aanbevolen VS Code Extensies
3.  [Project Klonen en Initiële Setup](#3-project-klonen-en-initiële-setup)
    *   3.1. Repository Klonen vanaf GitHub
    *   3.2. De `backend` map: Initialisatie en Configuratie
    *   3.3. De `frontend` map: Basisstructuur
    *   3.4. De `LICENSE` File
    *   3.5. Eerste Test: Werkt de Frontend met de Backend?
4.  [Prisma & Database Setup](#4-prisma-database-setup)
    *   4.1. Prisma Installeren en Initialiseren
    *   4.2. Database Model Definiëren (`schema.prisma`)
    *   4.3. Migratie Uitvoeren: Tabellen aanmaken in de Database
5.  [Backend API Implementatie](#5-backend-api-implementatie)
    *   5.1. `backend/src/db.js`: Prisma Client Instance
    *   5.2. `backend/src/controllers/usersController.js`: Business Logica
    *   5.3. `backend/src/routes/users.js`: API Endpoints
    *   5.4. `backend/src/routes/index.js`: Hoofdrouter
    *   5.5. `backend/server.js`: Hoofdserver Update
6.  [Git Workflow: Samenwerken aan Code](#6-git-workflow-samenwerken-aan-code)
    *   6.1. Onze Branching Strategie
    *   6.2. Stappenplan voor een Nieuwe Feature
    *   6.3. Wat te doen bij Merge Conflicten
7.  [Database Beheer & Ontwikkeling](#7-database-beheer-ontwikkeling)
    *   7.1. Migraties aanmaken na Schema Wijzigingen
    *   7.2. Testdata Toevoegen (Seeders)
    *   7.3. Database Inspecteren
8.  [Handige Commando's & Tips](#8-handige-commando-s-tips)
    *   8.1. Backend Server Commando's
    *   8.2. Prisma Commando's
    *   8.3. Git Commando's
9.  [Veelgestelde Vragen & Probleemoplossing (Troubleshooting)](#9-veelgestelde-vragen-probleemoplossing-troubleshooting)
10. [Succes!](#10-succes)

---

## 1. Project Overzicht

### 1.1. Wat is FATG?

"Food Around The Globe" (FATG) is een webapplicatie die de festivalervaring voor bezoekers wil verbeteren. De app richt zich op het bieden van relevante informatie over foodstands en evenementen, navigatie op het festivalterrein, en de mogelijkheid voor sociale interactie met vrienden. Ons doel is om bezoekers te helpen met informatievoorziening en het ontdekken van diverse food & culturen.

### 1.2. Onze Technologie Stack

We gebruiken een moderne en beginnersvriendelijke "full-stack" webarchitectuur:

*   **Frontend:** Pure HTML, CSS en JavaScript. Dit zijn de bestanden die de gebruiker in zijn browser ziet en waarmee hij interactie heeft.
*   **Backend:** Node.js met het Express.js framework. Dit is de "server" kant van onze applicatie, die logica uitvoert, met de database praat en API-endpoints levert aan de frontend.
*   **Database:** PostgreSQL. Dit is een robuust databasesysteem waar we al onze gegevens (gebruikers, foodstands, evenementen) opslaan.
*   **ORM (Object-Relational Mapper):** Prisma. Dit is een krachtige tool die ons helpt om op een makkelijke en veilige manier met de PostgreSQL database te praten vanuit onze Node.js backend code, zonder direct SQL te hoeven schrijven.
*   **Pakketbeheer:** `npm` (Node Package Manager). Gebruiken we om alle benodigde libraries voor de backend te installeren.
*   **Versiebeheer:** Git en GitHub. Hiermee beheren we onze code en werken we samen aan het project.

### 1.3. Ons Team & Onze Rollen

Ons team bestaat uit verschillende specialisten die nauw samenwerken volgens de Agile/Scrum methodiek:

*   **Software Engineers (2x):** Verantwoordelijk voor de gehele technische implementatie (frontend-logica, backend-API's, database-integratie met Prisma) en codekwaliteit.
*   **Media UI/UX Designer (1x):** Verantwoordelijk voor het gebruikersgericht ontwerpen (wireframes, mockups), het creëren van een aantrekkelijke gebruikersinterface en het bewaken van de user experience.
*   **Cloud & Infra & Security Specialist (1x):** Verantwoordelijk voor het opzetten, configureren en beveiligen van de projectinfrastructuur (hosting, servers, databases), continuous integration/deployment (CI/CD) en monitoring.

---

## 2. Voorbereiding: Essentiële Software Installeren

Voordat we starten met het project, moet iedereen de volgende software op zijn/haar computer installeren. Neem hier rustig de tijd voor.

**Belangrijk:** Open voor de commando's die hieronder staan altijd een **nieuwe terminal** (op Windows: Command Prompt of PowerShell; op macOS/Linux: Terminal/iTerm).

### 2.1. Visual Studio Code (VS Code)

Dit is de code-editor die we allemaal zullen gebruiken.
1.  **Download:** Ga naar [**code.visualstudio.com**](https://code.visualstudio.com/)
2.  **Installeer:** Volg de instructies voor jouw besturingssysteem.
3.  **Verifieer:** Open VS Code. We zouden de "Welcome" pagina moeten zien.

### 2.2. Node.js & npm

Node.js is de runtime voor onze backend; `npm` is de pakketbeheerder.
1.  **Download:** Ga naar [**nodejs.org**](https://nodejs.org/)
2.  **Installeer:** Download en installeer de **LTS (Long Term Support) versie**. Volg de installatiewizard; `npm` wordt hierbij automatisch mee geïnstalleerd.
3.  **Verifieer:** Open een **nieuwe terminal** en typ:
    ```bash
    node -v  # Moet v20.x.x of hoger tonen
    npm -v   # Moet 10.x.x of hoger tonen
    ```
    Als we hier foutmeldingen krijgen, is de installatie niet gelukt.

### 2.3. Git

Git is ons versiebeheersysteem voor code.
1.  **Download:** Ga naar [**git-scm.com/downloads**](https://git-scm.com/downloads)
2.  **Installeer:** Volg de installatie. Voor Windows kunnen we de meeste standaardinstellingen aanhouden.
3.  **Verifieer:** Open een **nieuwe terminal** en typ:
    ```bash
    git --version
    ```
    We zouden een versienummer moeten zien.

### 2.4. PostgreSQL Database

PostgreSQL is de database die onze backend gebruikt.

1.  **Aanbevolen Methode (voor Windows/macOS): Officiële Installer met pgAdmin**
    *   **Download:** Ga naar [**postgresql.org/download**](https://www.postgresql.org/download/) en kies jouw besturingssysteem.
    *   **Installeer:** Volg de installatiewizard. Let goed op het volgende:
        *   **Wachtwoord voor `postgres` gebruiker:** Je wordt gevraagd een wachtwoord in te stellen voor de `postgres` superuser. **Schrijf dit wachtwoord OP!** Dit is **cruciaal** voor de verbinding later.
        *   **Poort:** Laat deze op `5432` staan, tenzij we een goede reden hebben om het te wijzigen.
        *   **Installeer ook `pgAdmin`:** Dit is een grafische tool om onze database mee te beheren; erg handig.
    *   **Verifieer:** Na installatie zou PostgreSQL op de achtergrond moeten draaien. Open `pgAdmin` (via je startmenu/applicaties) en probeer te verbinden met de `postgres` server (`localhost:5432`) met het wachtwoord dat je hebt ingesteld.

2.  **Alternatieve Methode (voor Linux of als je Docker al gebruikt): Docker Desktop**
    *   **Installeer:** Ga naar [**docker.com/products/docker-desktop**](https://www.docker.com/products/docker-desktop) en installeer Docker Desktop.
    *   **Start Docker:** Zorg dat Docker Desktop actief is.
    *   **Database creëren (dit doen we pas in sectie 4):** Je zult later een PostgreSQL container starten met een commando, bijvoorbeeld:
        ```bash
        docker run --name fatg-postgres -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=jouwWachtwoord -e POSTGRES_DB=fatg_db -p 5432:5432 -d postgres:latest
        ```
        *   **Let op:** Vul bij `jouwWachtwoord` een **sterk wachtwoord** in en onthoud dit!

### 2.5. Aanbevolen VS Code Extensies

Installeer deze extensies in VS Code (ga naar de 'Extensions' tab links in VS Code, zoek en klik op 'Install'):

1.  **Live Server** (van Ritwick Dey): Voor het lokaal hosten van onze frontend met live-reloading.
2.  **ESLint** (van Microsoft): Helpt bij het schrijven van foutvrije en consistente JavaScript-code.
3.  **Prettier - Code formatter** (van Prettier): Formatteert automatisch code (HTML, CSS, JS) voor een uniforme stijl.
4.  **Prisma** (van Prisma): Biedt syntax highlighting en functionaliteit voor onze `schema.prisma` bestanden.

---

## 3. Project Klonen en Initiële Setup

Nu alle tools geïnstalleerd zijn, gaan we het project klonen en de basisstructuur opzetten.

### 3.1. Repository Klonen vanaf GitHub

1.  **Navigeer naar een geschikte map:** Open je terminal en ga naar de map waar je het project wilt opslaan (bijv. `C:\dev` of `~/development`).
    ```bash
    # Voorbeeld voor Windows
    cd C:\Users\JouwGebruiker\Documents\A - HBO-ICT Bachelor\SEM 1\challenge 2\ProductOmgeving
    ```
2.  **Kloon de repository:** Haal de code van GitHub op. Gebruik de HTTPS URL van onze repository.
    ```bash
    git clone [HTTPS_URL_VAN_ONZE_REPO] fatg-webapp
    ```
    *   Vervang `[HTTPS_URL_VAN_ONZE_REPO]` met de HTTPS kloon-URL van onze GitHub repository.
3.  **Navigeer naar de projectmap:**
    ```bash
    cd fatg-webapp
    ```
4.  **Verifieer de `develop` branch:** Wij werken op de `develop` branch. Controleer of je hierop staat. Zo niet, wissel dan:
    ```bash
    git checkout develop
    ```
    *   Als `develop` nog niet bestaat, zal Git zeggen dat hij hem aanmaakt. Zorg dan dat we later een `git pull origin develop` doen om de nieuwste code van die branch op te halen.
5.  **Open het project in VS Code:**
    ```bash
    code .
    ```
    *   (De punt `.` betekent: open de huidige map in VS Code)

### 3.2. De `backend` map: Initialisatie en Configuratie

We gaan de backend instellen in de `backend/` map van het project.

1.  **Navigeer naar de `backend` map in je terminal:**
    ```bash
    cd backend
    ```
2.  **Installeer Node.js afhankelijkheden:** Dit downloadt en installeert alle libraries die onze backend nodig heeft (Express, dotenv, cors, Prisma Client).
    ```bash
    npm install
    ```
    *   Dit maakt een `node_modules` map en een `package-lock.json` bestand aan.
3.  **Configureer omgevingsvariabelen (`.env`):**
    *   Open het bestand **`backend/.env`** in VS Code.
    *   Dit bestand bevat configuratie die niet publiek mag zijn (zoals database-wachtwoorden). Het wordt genegeerd door Git.
    *   Pas de `DATABASE_URL` variabele aan met **jouw persoonlijke PostgreSQL verbindingsgegevens**:
        ```ini
        PORT=3000
        DATABASE_URL="postgresql://[JOUW_DB_GEBRUIKERSNAAM]:[JOUW_DB_WACHTWOORD]@localhost:5432/fatg_db?schema=public"
        ```
        *   **Voorbeeld (meest waarschijnlijk):** Als je de `postgres` gebruiker en wachtwoord `mijnveiligeWachtwoord` hebt ingesteld en onze database `fatg_db` heet:
            ```ini
            DATABASE_URL="postgresql://postgres:mijnveiligeWachtwoord@localhost:5432/fatg_db?schema=public"
            ```
        *   **ZEER BELANGRIJK:** Vul hier de **exacte gebruikersnaam en het wachtwoord** in die je hebt ingesteld bij de PostgreSQL installatie! En zorg dat `fatg_db` de correcte databasenaam is.
    *   **Sla het `.env` bestand op.**
4.  **Verwijder `prisma.config.ts` (indien aanwezig):**
    *   Controleer of er een bestand genaamd `prisma.config.ts` bestaat in de `backend/` map. Als dit het geval is, moet je het **verwijderen** omdat het de Prisma configuratie kan verstoren.
    *   In de terminal (nog steeds in `backend/`):
        ```bash
        del prisma.config.ts  # Op Windows
        # of: rm prisma.config.ts # Op Linux/macOS
        ```
        *   Als het bestand niet bestaat, krijgen we een fout, maar dat is prima.
5.  **Prisma Client Genereren:** Dit commando leest ons `schema.prisma` bestand en genereert de code waarmee onze Node.js backend met de database kan communiceren.
    ```bash
    npx prisma generate
    ```
    *   We zouden nu moeten zien: `Environment variables loaded from .env` en `✔ Generated Prisma Client ...`

6.  **Start de Backend Server (Eerste keer):**
    *   ```bash
        node server.js
        ```
    *   **Controleer de output:** We zouden moeten zien `FATG Backend server draait op poort 3000` en de gedeeltelijke database URL.
    *   **Laat deze terminal open staan en de server draaien!** We hebben deze nodig voor de volgende stap.

### 3.3. De `frontend` map: Basisstructuur

De frontend zijn de statische bestanden die de gebruiker in de browser ziet.

1.  **Navigeer naar de `frontend` map in je terminal:**
    ```bash
    cd ../frontend # Ga één map omhoog naar fatg-webapp, dan naar frontend
    ```
2.  **Verifieer bestanden:** Controleer of de bestanden `index.html`, `style.css` en `app.js` aanwezig zijn. Zo niet, haal dan de laatste code op met `git pull origin develop`.
3.  **Open `index.html` in de browser:**
    *   Ga in VS Code naar de `frontend/` map.
    *   **Aanbevolen:** Klik met de rechtermuisknop op `index.html` en kies "Open with Live Server" (als je de extensie hebt geïnstalleerd).
    *   **Alternatief:** Navigeer in je bestandsverkenner naar `fatg-webapp/frontend/` en dubbelklik op `index.html`.
4.  **Controleer de Frontend in de Browser:**
    *   Open de **ontwikkelaarsconsole** in je browser (meestal door op `F12` te drukken).
    *   Ga naar het tabblad "Console". We zouden `Frontend is geladen!` moeten zien.
    *   Ga naar het tabblad "Network". Ververs de pagina (`Ctrl+R`). Zoek naar een `fetch` request naar `http://localhost:3000/api/users`. De **Status Code** moet `200 OK` zijn (ook al is de lijst nog leeg).

### 3.4. De `LICENSE` File

1.  **Navigeer naar de root van ons project:**
    ```bash
    cd .. # Ga vanuit frontend/ naar fatg-webapp/
    ```
2.  **Controleer `LICENSE`:** Zorg dat het `LICENSE` bestand aanwezig is. Zo niet, haal de nieuwste code op met `git pull origin develop`.

### 3.5. Eerste Test: Werkt de Frontend met de Backend?

Nu onze frontend en backend draaien, testen we de communicatie.

1.  **Zorg dat de Backend draait:** Controleer of in je terminal de `node server.js` nog steeds actief is.
2.  **Open de Frontend in je browser:** (zoals beschreven in 3.3).
3.  **Inspecteer de gebruikerslijst:**
    *   De "Lijst van gebruikers" zal waarschijnlijk de tekst "Nog geen gebruikers in de database. Voeg er een toe!" tonen. Dit is goed! Dit betekent dat de frontend de backend succesvol heeft gevraagd naar gebruikers en een lege lijst terugkreeg.
4.  **Voeg een testgebruiker toe:**
    *   Gebruik het formulier "Nieuwe gebruiker toevoegen" op de pagina.
    *   Vul "Test Naam" en "test@example.com" in.
    *   Klik op "Toevoegen".
5.  **Verifieer:**
    *   De nieuwe gebruiker zou nu in de lijst moeten verschijnen.
    *   In de browserconsole zien we mogelijk `Nieuwe gebruiker aangemaakt: ...`.
    *   In de terminal van de backend zien we mogelijk `Fout bij aanmaken gebruiker: ...` als er een probleem was, of niets bij succes.
    *   **BELANGRIJK:** Gebruik `pgAdmin` om te controleren of de gebruiker daadwerkelijk in de `fatg_db` tabel `User` is opgeslagen.
        *   Open `pgAdmin`, navigeer naar `Servers -> [Jouw Servernaam] -> Databases -> fatg_db -> Schemas -> public -> Tables -> user`.
        *   Rechtsklik op de `user` tabel en kies "View/Edit Data" -> "All Rows". We zouden onze toegevoegde gebruiker(s) moeten zien!

**Als dit allemaal lukt, hebben we de volledige basis opgezet!**

---

## 4. Prisma & Database Setup

Deze stappen zijn al deels doorlopen in sectie 3.2, maar hier leggen we het conceptueel uit en herhalen de migratie stap.

### 4.1. Prisma Installeren en Initialiseren

*   **Installatie:** `npm install prisma --save-dev` installeert de Prisma CLI. `npm install @prisma/client` installeert de Prisma Client runtime. Dit is al gebeurd met `npm install` in sectie 3.2.
*   **Initialisatie:** `npx prisma init --datasource-provider postgresql` creëert de `prisma/` map en `schema.prisma`. Dit is al gedaan.
*   **`backend/.env`:** Bevat onze `DATABASE_URL` die Prisma gebruikt om te verbinden.

### 4.2. Database Model Definiëren (`schema.prisma`)

De `prisma/schema.prisma` file beschrijft de structuur van onze database (welke tabellen we hebben, welke kolommen, relaties). Het is een "single source of truth" voor onze database.

*   **Locatie:** `backend/prisma/schema.prisma`
*   **Ons `User` Model:**
    ```prisma
    model User {
      id        Int       @id @default(autoincrement())
      name      String
      email     String    @unique
      createdAt DateTime  @default(now())
      updatedAt DateTime  @updatedAt
    }
    ```
    *   `@id`: Definieert `id` als de primaire sleutel.
    *   `@default(autoincrement())`: Zorgt dat `id` automatisch oploopt bij nieuwe records.
    *   `@unique`: Zorgt ervoor dat geen twee gebruikers hetzelfde e-mailadres kunnen hebben.
    *   `@default(now())`: Stelt `createdAt` automatisch in op het huidige tijdstip bij het aanmaken van een record.
    *   `@updatedAt`: Werkt `updatedAt` automatisch bij wanneer een record wordt gewijzigd.

### 4.3. Migratie Uitvoeren: Tabellen aanmaken in de Database

Migraties zijn een manier om versies van je databaseschema te beheren. Wanneer we `schema.prisma` wijzigen, gebruiken we een migratie om deze wijzigingen door te voeren in de daadwerkelijke database.

1.  **Navigeer naar de `backend` map:**
    ```bash
    cd fatg-webapp/backend
    ```
2.  **Voer de migratie uit:**
    ```bash
    npx prisma migrate dev --name jouw_migratie_naam
    ```
    *   **Wat dit doet:**
        *   Vergelijkt `schema.prisma` met de huidige status van je database.
        *   Als er verschillen zijn, genereert het een nieuw `.sql` bestand in `prisma/migrations/`.
        *   Vraagt om bevestiging om de SQL-code uit te voeren op je lokale database.
        *   Voert de SQL uit, waardoor tabellen worden aangemaakt of gewijzigd.
    *   **Belangrijk:** Elke keer dat we dit doen, genereert Prisma ook opnieuw de Client.

---

## 5. Backend API Implementatie

Hier leggen we de structuur van onze Express.js backend uit, zoals deze nu is opgezet.

### 5.1. `backend/src/db.js`: Prisma Client Instance

Dit bestand (`backend/src/db.js`) is verantwoordelijk voor het maken van één centrale instantie van de Prisma Client. Alle controllers importeren deze instantie om met de database te communiceren.

```javascript
// backend/src/db.js
const { PrismaClient } = require('@prisma/client');
const prisma = new PrismaClient();
module.exports = prisma;
```

### 5.2. `backend/src/controllers/usersController.js`: Business Logica

Controllers (`backend/src/controllers/`) bevatten de "business logica". Dit zijn de functies die bepalen *wat* er moet gebeuren wanneer een specifiek API-verzoek binnenkomt. Ze gebruiken de Prisma Client om gegevens op te halen, op te slaan, bij te werken of te verwijderen.

```javascript
// backend/src/controllers/usersController.js
const prisma = require('../db');

const usersController = {
    getAll: async (req, res) => {
        try {
            const users = await prisma.user.findMany();
            res.json(users);
        } catch (error) {
            console.error('Fout bij ophalen gebruikers:', error);
            res.status(500).json({ error: 'Er is een interne serverfout opgetreden bij het ophalen van gebruikers.' });
        }
    },

    create: async (req, res) => {
        const { name, email } = req.body;
        if (!name || !email) {
            return res.status(400).json({ error: 'Naam en e-mailadres zijn verplicht.' });
        }
        try {
            const newUser = await prisma.user.create({
                data: { name, email },
            });
            res.status(201).json(newUser);
        } catch (error) {
            console.error('Fout bij aanmaken gebruiker:', error);
            if (error.code === 'P2002' && error.meta?.target?.includes('email')) {
                return res.status(409).json({ error: 'Dit e-mailadres is al in gebruik.' });
            }
            res.status(500).json({ error: 'Er is een interne serverfout opgetreden bij het aanmaken van de gebruiker.' });
        }
    },
};

module.exports = usersController;
```

### 5.3. `backend/src/routes/users.js`: API Endpoints

Routes (`backend/src/routes/`) definiëren de "paden" of "endpoints" van onze API en koppelen deze aan de bijbehorende controllerfuncties.

```javascript
// backend/src/routes/users.js
const express = require('express');
const router = express.Router();
const usersController = require('../controllers/usersController');

router.get('/', usersController.getAll);
router.post('/', usersController.create);

module.exports = router;
```

### 5.4. `backend/src/routes/index.js`: Hoofdrouter

De `index.js` in de `backend/src/routes/` map is onze "hoofdrouter". Deze combineert alle individuele routemodules (zoals `users.js`) en exporteert ze als één geheel.

```javascript
// backend/src/routes/index.js
const express = require('express');
const router = express.Router();

const userRoutes = require('./users');

router.use('/users', userRoutes);
// TODO: Voeg hier later andere routers toe (bijv. router.use('/events', eventRoutes);)

module.exports = router;
```

### 5.5. `backend/server.js`: Hoofdserver Update

De `server.js` file is het startpunt van onze Express backend. Hier configureren we middleware (zoals `cors` en `express.json`) en 'mounten' we onze hoofdrouter onder het `/api` pad.

```javascript
// backend/server.js
require('dotenv').config();
const express = require('express');
const cors = require('cors');
const app = express();
const router = require('./src/routes');
const PORT = process.env.PORT || 3000;

app.use(cors());
app.use(express.json());

app.use('/api', router);

app.get('/', (req, res) => {
    res.send('Welkom bij de FATG Backend API. Gebruik /api/users voor gebruikersdata.');
});

app.listen(PORT, () => {
    console.log(`FATG Backend server draait op poort ${PORT}`);
    console.log(`Database URL: ${process.env.DATABASE_URL.split('@')[1]}`);
});
```

---

## 6. Git Workflow: Samenwerken aan Code

We gebruiken Git en GitHub om onze code te beheren en samen te werken. Onze workflow zorgt voor gestructureerde ontwikkeling en kwaliteitsborging.

### 6.1. Onze Branching Strategie

We volgen een "Feature Branch Workflow" met twee beschermde hoofdbranches:

*   **`main` branch:**
    *   Bevat altijd de meest stabiele, productieklare code.
    *   Hier worden wijzigingen alleen naar gemerged aan het einde van een sprint of voor een release, na uitgebreide tests in `develop`.
    *   **Directe pushes zijn NIET toegestaan.** Alle wijzigingen moeten via een goedgekeurde Pull Request (`PR`) vanuit `develop`.
*   **`develop` branch:**
    *   Dit is onze hoofd-ontwikkelbranch. Alle afgeronde features komen hierin samen.
    *   **Directe pushes zijn NIET toegestaan.** Alle wijzigingen moeten via een goedgekeurde Pull Request (`PR`) vanuit een feature-branch.
*   **`feature/jouw-feature-naam` branches:**
    *   Voor elke nieuwe functionaliteit, bugfix of user story die je oppakt, maken we een aparte feature-branch aan.
    *   Deze branches worden **afgesplitst van `develop`** en **mergen terug naar `develop`**.
    *   Na het mergen wordt de feature-branch verwijderd.

### 6.2. Stappenplan voor een Nieuwe Feature

Volg dit proces elke keer dat je aan een nieuwe User Story of taak begint:

1.  **Zorg dat onze `develop` up-to-date is:**
    *   Ga naar de root van ons project (`fatg-webapp/`).
    *   ```bash
        git checkout develop
        git pull origin develop
        ```
2.  **Maak een nieuwe feature-branch aan:** Geef je branch een duidelijke, korte naam die beschrijft waaraan je werkt (bijv. `feature/user-crud`, `feature/map-view`).
    *   ```bash
        git checkout -b feature/naam-van-jouw-feature
        ```
3.  **Ontwikkel je feature:**
    *   Schrijf code, voeg bestanden toe, test je functionaliteit lokaal.
    *   Sla je wijzigingen regelmatig op in Git (commit). Gebruik beschrijvende commit-berichten.
    *   ```bash
        git add . # Voegt alle gewijzigde/nieuwe bestanden toe
        git commit -m "feat: Implementeer basis CRUD voor gebruikers" # Voorbeeld commit message
        ```
4.  **Push je feature-branch naar GitHub:**
    *   ```bash
        git push -u origin feature/naam-van-jouw-feature
        ```
    *   De `-u` is alleen nodig de eerste keer om de 'upstream' (tracking) branch in te stellen. Daarna is `git push` voldoende.
5.  **Open een Pull Request (PR):**
    *   Ga naar onze GitHub repository in je browser. GitHub zal automatisch voorstellen om een PR te openen van jouw `feature/` branch naar de **`develop` branch**.
    *   Vul een duidelijke **titel** in (bijv. "feat: Implementatie van gebruikers CRUD").
    *   Schrijf een gedetailleerde **beschrijving** van wat je hebt gedaan, welke problemen je hebt opgelost en welke functionaliteit je hebt toegevoegd.
    *   **Wijs minimaal één ander teamlid aan als reviewer.**
6.  **Code Review & Goedkeuring:**
    *   De aangewezen reviewer zal je code bekijken, vragen stellen en suggesties doen.
    *   Los eventuele opmerkingen op door extra commits naar je feature-branch te pushen (de PR wordt dan automatisch bijgewerkt).
    *   **De PR moet goedgekeurd worden door een ander teamlid voordat deze kan mergen.**
7.  **Merge naar `develop`:**
    *   Zodra je PR is goedgekeurd en alle gesprekken zijn opgelost, kan de PR gemerged worden naar de `develop` branch. Dit kan door jouzelf of de reviewer gedaan worden via de GitHub interface.
8.  **Verwijder de Feature Branch (opruimen):**
    *   Na een succesvolle merge, verwijder je je feature-branch op GitHub via de PR-interface.
    *   Verwijder de lokale branch ook om je repository schoon te houden:
        ```bash
        git branch -d feature/naam-van-jouw-feature
        ```
        *   (Gebruik `-D` i.p.v. `-d` als de branch nog niet volledig is gemerged of conflicten heeft.)

### 6.3. Wat te doen bij Merge Conflicten

Merge conflicten ontstaan wanneer twee (of meer) personen wijzigingen aan dezelfde regels code hebben gemaakt in verschillende branches die moeten samenkomen.

1.  **Pull de nieuwste `develop`:** Zorg altijd dat je de laatste `develop` branch hebt voordat je probeert te mergen of rebasen.
2.  **Identificeer Conflicten:** Git zal je vertellen dat er conflicten zijn. Je bestanden zullen markeringslijnen bevatten zoals `<<<<<<<`, `=======`, `>>>>>>>`.
3.  **Los Conflicten op:**
    *   Open het geconflicteerde bestand in VS Code.
    *   VS Code heeft ingebouwde tools om merge conflicten visueel op te lossen. Kies welke versie van de code je wilt behouden (jouw wijzigingen, de inkomende wijzigingen van `develop`, of een combinatie van beide).
    *   Verwijder de `<<<<<<<`, `=======`, `>>>>>>>` markeringslijnen handmatig.
4.  **Markeer als Opgelost:**
    *   ```bash
        git add . # Markeer het bestand als opgelost
        ```
5.  **Commit de Oplossing:**
    *   ```bash
        git commit -m "fix: Los merge conflict op voor [naam bestand]"
        ```
6.  **Push:** Push je opgeloste branch en ga verder met de PR.

---

## 7. Database Beheer & Ontwikkeling

### 7.1. Migraties aanmaken na Schema Wijzigingen

Wanneer we de structuur van onze database willen wijzigen (bijv. een nieuwe tabel toevoegen, een kolom toevoegen/verwijderen), doen we dit via `prisma/schema.prisma` en daarna een migratie.

1.  **Wijzig `prisma/schema.prisma`:**
    *   Voeg een nieuw `model` toe (bijv. `Event`, `FoodStand`).
    *   Of wijzig een bestaand model (voeg een kolom toe, verander een type).
2.  **Navigeer naar de `backend` map:**
    ```bash
    cd fatg-webapp/backend
    ```
3.  **Creëer een nieuwe migratie:** Geef de migratie een beschrijvende naam.
    ```bash
    npx prisma migrate dev --name naam_van_je_nieuwe_migratie
    ```
    *   **Wat dit doet:**
        *   Vergelijkt `schema.prisma` met de huidige status van je database.
        *   Als er verschillen zijn, genereert het een nieuw SQL-bestand in `prisma/migrations/`.
        *   Vraagt om bevestiging om de SQL-code uit te voeren op je lokale database.
        *   Voert de SQL uit, waardoor tabellen worden aangemaakt of gewijzigd.
    *   **Belangrijk:** Elke keer dat we dit doen, genereert Prisma ook opnieuw de Client.

### 7.2. Testdata Toevoegen (Seeders)

Seeders zijn handig om testdata in onze database te plaatsen, zodat we niet elke keer handmatig data hoeven in te voeren.

1.  **Maak een seeder bestand aan:**
    ```bash
    npx prisma db seed --create-only
    ```
    *   Dit genereert een bestand `prisma/seed.ts` (of `seed.js`).
2.  **Vul de seeder:** Open `prisma/seed.ts` en voeg logica toe om data aan je tabellen toe te voegen (bijv. via `prisma.user.create()` of `createMany()`).
3.  **Voer de seeder uit:**
    ```bash
    npx prisma db seed
    ```

### 7.3. Database Inspecteren

*   **Via pgAdmin:** Gebruik `pgAdmin` om visueel je tabellen te bekijken, gegevens te bewerken of SQL-query's uit te voeren.
*   **Via Prisma Studio:** Dit is een grafische UI van Prisma om je database te bekijken en te bewerken.
    1.  Navigeer naar de `backend` map.
    2.  ```bash
        npx prisma studio
        ```
    3.  Dit opent een webpagina (meestal op `http://localhost:5555`) waar je al je modellen en data kunt zien.

---

## 8. Handige Commando's & Tips

### 8.1. Backend Server Commando's (in `backend/` map)

*   **Start de server:**
    ```bash
    node server.js
    ```
*   **Installeer nieuwe Node.js pakketten:**
    ```bash
    npm install [pakketnaam]        # Als normale dependency
    npm install [pakketnaam] --save-dev # Als development dependency
    ```
*   **Herstart de server bij elke wijziging (aanbevolen voor ontwikkeling):**
    *   Installeer `nodemon` globaal of als dev dependency: `npm install -g nodemon` of `npm install nodemon --save-dev`
    *   Voeg in `package.json` een script toe: `"dev": "nodemon server.js"`
    *   Start dan met: `npm run dev`

### 8.2. Prisma Commando's (in `backend/` map)

*   **Genereer de Prisma Client:**
    ```bash
    npx prisma generate
    ```
*   **Voer migraties uit:**
    ```bash
    npx prisma migrate dev --name jouw_migratie_naam
    ```
*   **Open Prisma Studio (database UI):**
    ```bash
    npx prisma studio
    ```
*   **Verwijder de database en pas alle migraties opnieuw toe:** (Voor een schone start, **wees voorzichtig!** Dit verwijdert alle data.)
    ```bash
    npx prisma migrate reset
    ```

### 8.3. Git Commando's (in project root `fatg-webapp/` of `backend/`/`frontend/` afhankelijk van scope)

*   **Status controleren:**
    ```bash
    git status
    ```
*   **Wijzigingen toevoegen:**
    ```bash
    git add . # Alles toevoegen
    git add path/to/file.js # Specifiek bestand toevoegen
    ```
*   **Commit wijzigingen:**
    ```bash
    git commit -m "feat: Korte beschrijving van de feature"
    ```
*   **Pushen naar GitHub:**
    ```bash
    git push origin jouw-branch-naam
    ```
*   **Nieuwste code ophalen van een branch:**
    ```bash
    git pull origin develop # Haalt de nieuwste code van develop op
    ```
*   **Branch wisselen:**
    ```bash
    git checkout develop
    ```
*   **Nieuwe branch aanmaken en wisselen:**
    ```bash
    git checkout -b feature/nieuwe-feature-naam
    ```

---

## 9. Veelgestelde Vragen & Probleemoplossing (Troubleshooting)

*   **"Error: Cannot find module '...server.js'" of soortgelijke `node` fout:** Je bent waarschijnlijk in de verkeerde map. Zorg dat je in de `backend/` map bent voordat je `node server.js` uitvoert.
*   **"P1000: Authentication failed against database server" (Prisma fout):** Je `DATABASE_URL` in `backend/.env` is incorrect. Controleer:
    *   `Gebruikersnaam` en `Wachtwoord` komen exact overeen met je PostgreSQL gebruiker.
    *   `fatg_db` komt exact overeen met de databasenaam in pgAdmin.
    *   Alle delen van de URL zijn correct ingevuld.
*   **"CORS error" in de browser console (rood gekleurd):** Dit betekent dat onze frontend geen verbinding mag maken met de backend.
    *   Zorg dat `app.use(cors());` in `backend/server.js` staat.
    *   Zorg dat je backend server draait.
    *   Zorg dat onze frontend op `http://localhost:3000` (of de juiste backend poort) probeert te verbinden.
*   **"Fetch failed to load resource" of "Network Error" in browser console:** De frontend kan de backend niet bereiken.
    *   Is de backend server gestart (`node server.js`)?
    *   Draait de backend op de juiste poort (`http://localhost:3000`) zoals geconfigureerd in `app.js`?
    *   Zijn er geen firewall-regels die de verbinding blokkeren?

---

## 10. Succes!

Dit is veel informatie, maar het is allemaal ontworpen om ons zo goed mogelijk op weg te helpen. Neem de tijd om het te absorberen, experimenteer ermee, en vraag vooral veel! Samen zullen we "Food Around The Globe" tot een succes maken.

Veel plezier met coderen!
