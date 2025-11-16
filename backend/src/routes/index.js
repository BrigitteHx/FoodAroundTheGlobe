const express = require('express');
const router = express.Router(); 

const userRoutes = require('./users'); 

router.use('/users', userRoutes);

// TODO: Voeg hier later andere routers toe (bijv. router.use('/events', eventRoutes);)

module.exports = router; 