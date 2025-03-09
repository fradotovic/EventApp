## 1.  Vite dev za react okruženje potrebno instalirati 
### npm create vite@latest --> samo pokrenes u app i pratis korake

## 2. vite.config.ts -> ovdje možeš specificirati server 
--odnosno port na kojem će taj server raditi

## 3. Dodaj extension -> ES7+ React/Redux/React-Native snippets i ESLint


## 4. Da tvoj browser vjeruje https certifikatu možeš instalirati sljedeće
 ### npm i -D vite-plugin-mkcert
   -- i onda u vite.config.ts dodaas 
import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react-swc'
import mkcert from 'vite-plugin-mkcert';

// https://vite.dev/config/
export default defineConfig({
  server: {
    port: 3000
  },
  plugins: [react(), mkcert()],
})

