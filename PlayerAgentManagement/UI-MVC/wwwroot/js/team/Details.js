/**
 * @type {HTMLTableSectionElement}
 */

const tableBody = document.getElementById('teamTableBody');

/**
 * @type {HTMLSelectElement}
 */

const playerSelect = document.getElementById('playerSelect');

/**
 * @type {HTMLInputElement}
 */

const startDate = document.getElementById('startDate');

/**
 * @type {HTMLInputElement}
 */

const endDate = document.getElementById('endDate');

/**
 * @type {HTMLInputElement}
 
 */

const salary = document.getElementById('salary');

/**
 * @type {HTMLButtonElement}
 */

const addButton = document.getElementById('addButton');

function getTeamId() {
    const urlSearchParams = new URLSearchParams(window.location.search);
    let teamId = urlSearchParams.get("id");
    if (!teamId) {
        const path = window.location.pathname;
        teamId = path.substring(path.lastIndexOf("/") + 1);
    }
    console.log("URL: ", window.location.href);
    console.log("Team ID: ", teamId);
    return parseInt(teamId);
}


async function loadAllPlayers() {
    const response = await fetch(`/api/players/allPlayers`, {
        headers: {
            Accept: "application/json"
        }
    });
    if (response.status === 200) {
        const players = await response.json();

        playerSelect.innerHTML = '';
        for (const player of players) {
            playerSelect.innerHTML += `
                <option value="${player.id}">${player.name}</option>
                `;
        }
    } else {
        playerSelect.innerHTML = `
                <option value="">No players were found!</option>
                `;
    }
}

async function addNewContract() {
 const response = await fetch('/api/Teams/addContract',
        {
            method: "POST",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                "teamId": getTeamId(),
                "playerId": playerSelect.options[playerSelect.selectedIndex].value,
                "startDate": startDate.value,
                "endDate": endDate.value,
                "salary": salary.value
            })
        }
    );
    if (response.status === 200) {
        document.getElementsByTagName('form')[0].reset();
        loadAllPlayersOfTeam();
    } else {
        console.error("Failed to add contract");
    }
    
}

loadAllPlayers().then(r => console.log(r));

addButton.addEventListener('click', addNewContract);