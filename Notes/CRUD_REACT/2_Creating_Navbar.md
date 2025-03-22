## Komponenta je zapravo Javascript funkcija koja vraća .jsx

## rfc je shortcut za boilerplate komponente da se kreira

### 3. Ako komponenta nema children možes ju pozvati samo kao self closing tag <Navbar/>

### Pronađeš komponentu na MaterialUI u ovom slučaju za NavBar koristimo AppBar skopiras kod i importas je 
-- i tamo gdje pozivas komponentu u ovom slučaju App.tsx, moras dodati i <CssBaseline/> da resetiras css dovezen s MaterialUI

--<Box></Box> -> ekvivalent divu
--Container se koristi za glavni layout i da se postavi na full width

### kada se koriste brojke u npr margintop ili ostalim takvim propertyima ide se s time da je 1 * 8px


import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import { Button, Container, MenuItem } from '@mui/material';
import { Group } from '@mui/icons-material';

export default function NavBar() {
    return (
        <Box sx={{ flexGrow: 1 }}>
            <AppBar position="static"
                sx={{ backgroundImage: 'linear-gradient(135deg,#182a73 0%, #218aae 69%, #20a7ac 89%)' }}>
                <Container maxWidth='xl'>
                    <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
                        <Box>
                            <MenuItem sx={{ display: 'flex', gap: 2 }}>
                                <Group fontSize='large' />
                                <Typography variant='h6' fontWeight='bold'>EventApp</Typography>
                            </MenuItem>
                        </Box>
                        <Box sx={{ display: 'flex', gap: 2 }}>
                            <MenuItem sx={{ fontSize: '14px', textTransform: 'uppercase', fontWeight: 'bold' }}>
                                Activities
                            </MenuItem>

                            <MenuItem sx={{ fontSize: '14px', textTransform: 'uppercase', fontWeight: 'bold' }}>
                                About
                            </MenuItem>

                            <MenuItem sx={{ fontSize: '14px', textTransform: 'uppercase', fontWeight: 'bold' }}>
                                Contact
                            </MenuItem>
                        </Box>

                        <Button size='medium' variant='contained' color='warning'>Create Activity</Button>
                    </Toolbar>
                </Container>
            </AppBar>
        </Box>
    );
}
