## Klase se stvaraju u DOMAIN folderu

- da Entity Framework može pristupiti klasi one moraju biti postavljene na public

-- public string Id { get; set; } = Guid.NewGuid().ToString(); ne oslanjamo se na bazu podataka da generira širu za ključ

