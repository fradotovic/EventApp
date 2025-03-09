## u client app instaliraj axios
 ### npm install axios


 ## 2. možeš zamjeniti zatim fetch sa ovime

  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get<Activity[]>('https://localhost:5001/api/activities')
      .then(response => setActivities(response.data))

    return () => { }

  }, [])