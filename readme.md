# VehicleInformation

Query and parse vehicle information from the Norwegian Vegvesen website.

```csharp
var dict = VehicleInformation.Query('VH15836');
```

This will return a `Dictionary<string, Dictionary<string, string>>` object containing all public data about the vehicle.

The dump will look something like this:

```json
{
	"Generelt": {
		"Registreringsnummer": "VH 15836",
		"Merke og modell": "MAZDA 3",
		"Kjøretøygruppe": "Personbil",
		"Registreringsår": "2009",
		"Antall seter": "5",
		"Farge": "Gul",
		"Understellsnummer": "JMZBL14Z201105800",
		"Registrert første gang i Norge": "23.07.2009",
		"Registrert første gang på eier": "08.03.2013",
		"Registrert i distrikt": "Trondheim",
		"Sist EU-godkjent": "21.04.2015",
		"Neste frist for godkjent EU-kontroll": "30.06.2017",
		"Oppbygd": "Nei",
		"Bruktimportert": "Nei"
	},
	"Mål og vekt": {
		"Lengde": "446 cm",
		"Bredde": "176 cm",
		"Egenvekt": "1 180 kg",
		"Egenvekt med fører": "1 255 kg",
		"Tillatt totalvekt": "1 770 kg",
		"Maks nyttelast": "515 kg",
		"Maksvekt tilhenger m/brems": "930 kg",
		"Maksvekt tilhenger u/brems": "550 kg",
		"Maksvekt på tilhengerkobling": "75 kg",
		"Maks vogntogvekt": "2 700 kg",
		"Maks taklast": "Ikke oppgitt",
		"Maks aksellast foran": "925 kg",
		"Maks aksellast bak": "920 kg"
	},
	"Motor/kraftoverføring": {
		"Slagvolum": "1 598 cm<sup>3</sup>",
		"Drivstoff": "Bensin",
		"Motorytelse/effekt": "77 KW (105 HK)",
		"Antall aksler": "2",
		"Antall aksler med drift": "1"
	},
	"Dekk/felg": {
		"Dekk foran (standard)": "195/65R15",
		"Dekk bak (standard)": "195/65R15",
		"Hastighetsindeks": "T (190 km/t)",
		"Lastindeks foran": "82",
		"Lastindeks bak": "82",
		"Innpress foran": "50 mm",
		"Innpress bak": "50 mm"
	},
	"Kilometerstand": {
		"17.04.2015": "107 294",
		"15.07.2013": "93 541"
	}
}
```