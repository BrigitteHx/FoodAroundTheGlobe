require('dotenv').config(); 
const express = require('express');
const cors = require('cors');
const app = express();
const router = require('./src/routes'); 
const PORT = process.env.PORT || 3000;

// Middleware: Verwerken van inkomende requests
app.use(cors()); 
app.use(express.json()); 

// Koppel al onze API-routes onder het '/api' pad
// Alle routes die we definiëren in src/routes/index.js (en sub-routers)
// zijn nu bereikbaar via http://localhost:3000/api/...
app.use('/api', router);

app.get('/', (req, res) => {
    res.send('Welkom bij de FATG Backend API. Gebruik /api/users voor gebruikersdata.');
});

// Start de server
app.listen(PORT, () => {
    console.log(`FATG Backend server draait op poort ${PORT}`);
    console.log(`Database URL: ${process.env.DATABASE_URL.split('@')[1]}`); // Voor debugging, log alleen host/port/db
});