const prisma = require('../db'); 

const usersController = {
    getAll: async (req, res) => {
        try {
            const users = await prisma.user.findMany();
            res.json(users); 
        } catch (error) {
            console.error('Fout bij ophalen gebruikers:', error); 
            res.status(500).json({ error: 'Er is een interne serverfout opgetreden bij het ophalen van gebruikers.' });
        }
    },

    create: async (req, res) => {
        const { name, email } = req.body; 

        if (!name || !email) {
            return res.status(400).json({ error: 'Naam en e-mailadres zijn verplicht.' });
        }

        try {
            const newUser = await prisma.user.create({
                data: { name, email }, 
            });
            res.status(201).json(newUser); 
        } catch (error) {
            console.error('Fout bij aanmaken gebruiker:', error);
            if (error.code === 'P2002' && error.meta?.target?.includes('email')) {
                return res.status(409).json({ error: 'Dit e-mailadres is al in gebruik.' });
            }
            res.status(500).json({ error: 'Er is een interne serverfout opgetreden bij het aanmaken van de gebruiker.' });
        }
    },

    // Voeg hier later methodes toe voor getById, update, delete
};

module.exports = usersController; 