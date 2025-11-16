// frontend/app.js
const API_BASE_URL = 'http://localhost:3000/api'; // Zorg dat dit overeenkomt met je backend poort !!!

document.addEventListener('DOMContentLoaded', () => {
    console.log('Frontend is geladen!');
    loadUsers(); 

    const addUserForm = document.getElementById('add-user-form');
    if (addUserForm) {
        addUserForm.addEventListener('submit', handleAddUser);
    }
});

async function loadUsers() {
    try {
        const response = await fetch(`${API_BASE_URL}/users`);
        const users = await response.json();
        displayUsers(users);
    } catch (error) {
        console.error('Fout bij ophalen gebruikers:', error);
        const userList = document.getElementById('user-list');
        if (userList) {
            userList.innerHTML = '<li>Kan gebruikers niet laden. Zorg dat de backend draait en geconfigureerd is.</li>';
        }
    }
}

function displayUsers(users) {
    const userList = document.getElementById('user-list');
    if (!userList) return;

    userList.innerHTML = ''; 
    if (users.length === 0) {
        userList.innerHTML = '<li>Nog geen gebruikers in de database. Voeg er een toe!</li>';
        return;
    }

    users.forEach(user => {
        const li = document.createElement('li');
        li.textContent = `ID: ${user.id}, Naam: ${user.name}, E-mail: ${user.email}`;
        userList.appendChild(li);
    });
}

async function handleAddUser(event) {
    event.preventDefault(); 

    const userNameInput = document.getElementById('userName');
    const userEmailInput = document.getElementById('userEmail');

    const name = userNameInput.value;
    const email = userEmailInput.value;

    try {
        const response = await fetch(`${API_BASE_URL}/users`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ name, email }),
        });

        if (!response.ok) {
            const errorData = await response.json();
            throw new Error(errorData.error || 'Fout bij toevoegen gebruiker');
        }

        const newUser = await response.json();
        console.log('Nieuwe gebruiker aangemaakt:', newUser);
        userNameInput.value = ''; 
        userEmailInput.value = '';
        loadUsers(); 
    } catch (error) {
        console.error('Fout bij aanmaken gebruiker:', error);
        alert(`Fout: ${error.message}`);
    }
}