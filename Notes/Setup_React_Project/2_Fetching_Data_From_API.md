## 1. To se radi u tsx. fileovima

## 2. Pozivanje api-ja pomoću hooksa i onda prikaz u app

const [activities, setActivities] = useState([]);

  useEffect(() => {
    fetch('https://localhost:5001/api/activities')
      .then(response => response.json())
      .then(data => setActivities(data))

  }, [])

  return (
    <><div>
      <h3>EventApp</h3>
      <ul>
        {activities.map((activitiy) => (
          <li key={activitiy.id}>activitiy.title</li>
        ))}
      </ul>
    </div>

    </>
  )


  ## 3. Da bi omogićio CORS treba u .NET Projektu jos posložiti sljedeće da REACT može pozivati API-je

- U Program.cs potrebno dodati sljedeće :

## builder.Services.AddCors(); 

--obavezno prije app.MapControllers---
## app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000","https://localhost:3000")); 

--sada bi trebao moći prikazati podatke o API-u u react app

import { useEffect, useState } from "react"

function App() {

  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    fetch('https://localhost:5001/api/activities')
      .then(response => response.json())
      .then(data => setActivities(data))

    return () => { }

  }, [])

  return (
    <><div>
      <h3>EventApp</h3>
      <ul>
        {activities.map((activitiy) => (
          <li key={activitiy.id}>{activitiy.title}</li>
        ))}
      </ul>
    </div>

    </>
  )
}


## u index.d.ts -> slažeš tipove podataka, možeš konvertati direktno iz json u TS