document.addEventListener("DOMContentLoaded", function() {
    loadAgents();
    document.getElementById("refreshButton").addEventListener("click", loadAgents);
});

function loadAgents() {
    fetch('/api/Agents')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(agents => {
            displayAgents(agents);
        })
        .catch(error => {
            console.error('There has been a problem with your fetch operation:', error);
        });
}

function displayAgents(agents) {
    const tableBody = document.getElementById('manTableBody');
    tableBody.innerHTML = ''; // Clear existing data

    const table = document.createElement('table');
    table.classList.add('table');

    const thead = table.createTHead();
    const headerRow = thead.insertRow();
    const headers = ['ID', 'Name', 'BirthDate', 'PhoneNumber'];
    headers.forEach(headerText => {
        const header = document.createElement('th');
        header.textContent = headerText;
        headerRow.appendChild(header);
    });

    const tbody = table.createTBody();
    agents.forEach(agent => {
        const row = tbody.insertRow();
        Object.values(agent).forEach(text => {
            const cell = row.insertCell();
            cell.textContent = text;
        });
    });

    tableBody.appendChild(table);
}
