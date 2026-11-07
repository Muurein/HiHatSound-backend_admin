# Hi-Hat Sound - backend
Projektet är tänkt att fungera som en företagssida för företaget Hi-Hat Sound, som erbjuder tjänster som poddklippning. En autentiserad administratör ska kunna logga in i ett administrationsgränssnitt för att ändra bilder i ett galleri från event företaget har jobbat med och uppdatera en lista över poddar som de klippt. Poddarna och galleriet visas i en separat frontend. 

Projektet byggdes som examensarbetet för min utbildning och inom tidsramarna för detta har administrationsgränssnittet inte stylats utöver den styling som ASP.NET Core Razor Pages erbjuder.

Dessutom rekommenderas att utgå från dev-grenen, eftersom flertalet filer har försvunnit vid olika försök att slå samman grenarna. 

## Relaterade projekt
Hi-Hat Sound - frontend: https://github.com/Muurein/HiHatSound-frontend 

## Tekniker
- C#
- .NET
- ASP.NET Core
- Entity Framework Core
- SQLite
- ASP-NET Core Identity
- ASP.NET Core Razor Pages

## Funktioner
- REST API byggd med ASP.NET Core controllers.
- CRUD-funktioner för galleriet.
- CRUD-funktioner för listan över poddar.
- Entity Framework Core och SQLite för databashantering.
- ASP.NET Core Identity för att hantera autentisering och inloggning.
- Razor Pages för administrationsgränssnittet.


## API-ändpunkter
Informationen valideras innan en ny bild eller podd kan läggas till.

### Galleriet

| Metod  | Ändpunkt           | Beskrivning                                |
| ------ | -------------------| ------------------------------------------ |
| GET    | /api/gallery       | Publik. Hämta alla bilder.                 |
| GET    | /api/gallery/{id}  | Publik. Hämta en särskild bild.            |
| POST   | /api/gallery       | Autentiserad. Lägg till en bild.           |
| PUT    | /api/gallery/{id}  | Autentiserad. Uppdatera en särskild bild.  |
| DELETE | /api/gallery/{id}  | Autentiserad. Ta bort en särskild bild.    |

Innehåller ett ID och en bild-URL.

Exempel i JSON:
{
  "imageUrl": "https://example.com/image.jpg"
}



### Poddar

| Metod  | Ändpunkt                 | Beskrivning                                |
| ------ | ------------------------ | ------------------------------------------ |
| GET    | /api/poddportfolio       | Publik. Hämta alla poddar.                 |
| GET    | /api/poddportfolio/{id}  | Publik. Hämta en särskild podd.            |
| POST   | /api/poddportfolio       | Autentiserad. Lägg till en podd.           |
| PUT    | /api/poddportfolio/{id}  | Autentiserad. Uppdatera en särskild podd.  |
| DELETE | /api/poddportfolio/{id}  | Autentiserad. Ta bort en särskild podd.    |

Innehåller en titel, Spotify-länk, RSS-feed och en bild-URL.

Exempel i JSON:
{
  "title": "Exempel podd",
  "spotifyLink": "https://open.spotify.com/",
  "rssFeed": "https://example.com/feed.xml",
  "imageUrl": "https://example.com/podcast-cover.jpg"
}


## Kom igång med projektet

### Tekniska förutsättningar
- .NET v.10

### Kommando
- dotnet run: kör projektet
- dotnet ef database update: för att uppdatera databasen eller för att skapa databasen om den inte redan finns


