//import './App.css'
import { List, ListItem, ListItemText, Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react"

function App() {

  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get<Activity[]>('https://localhost:5001/api/activities')
      .then(response => setActivities(response.data))

    return () => { }

  }, [])

  return (
    <>

      <>
        <Typography variant='h3'>EventApp</Typography>
        <List>
          {activities.map((activitiy) => (
            <ListItem key={activitiy.id}>
              <ListItemText>{activitiy.title}</ListItemText>
            </ListItem>
          ))}
        </List>
      </>

    </>
  )
}

export default App
