let loadedTeams = []; // Global array to store loaded teams

const dropZone = document.getElementById("dropZone");

dropZone.addEventListener("click", () => {
  const fileInput = document.createElement("input");
  fileInput.type = "file";
  fileInput.accept = ".txt";
  fileInput.addEventListener("change", handleFile);
  fileInput.click();
});

dropZone.addEventListener("dragover", (event) => {
  event.preventDefault();
  dropZone.classList.add("dragover");
});

dropZone.addEventListener("dragleave", () => {
  dropZone.classList.remove("dragover");
});

dropZone.addEventListener("drop", (event) => {
  event.preventDefault();
  dropZone.classList.remove("dragover");

  const file = event.dataTransfer.files[0];
  if (file && file.type === "text/plain") {
    handleFile({ target: { files: [file] } });
  } else {
    alert("Please drop a valid .txt file.");
  }
});

function handleFile(event) {
  const file = event.target.files[0];
  if (!file) return;

  const reader = new FileReader();
  reader.onload = function (e) {
    const text = e.target.result;
    parseFileContent(text);
  };
  reader.readAsText(file);
}

function parseFileContent(text) {
  const newTeams = [];
  const lines = text.split("\n");
  let currentTeam = null;

  lines.forEach((line) => {
    line = line.trim();

    if (line.startsWith("Team")) {
      currentTeam = { team: line, members: [] };
      newTeams.push(currentTeam);
    } else if (line && currentTeam) {
      const [name, description] = line.split("\t").map((item) => item.trim());
      if (name && description) {
        currentTeam.members.push({ name, description });
      }
    }
  });

  // Merge new teams into loaded teams
  newTeams.forEach((newTeam) => {
    const existingTeam = loadedTeams.find((team) => team.team === newTeam.team);
    if (existingTeam) {
      newTeam.members.forEach((newMember) => {
        if (
          !existingTeam.members.some((member) => member.name === newMember.name)
        ) {
          existingTeam.members.push(newMember);
        }
      });
    } else {
      loadedTeams.push(newTeam);
    }
  });

  renderTables(loadedTeams);
}

function renderTables(teams) {
  const teamTableBody = document.querySelector("#teamTable tbody");
  const studentTableBody = document.querySelector("#studentTable tbody");
  teamTableBody.innerHTML = "";
  studentTableBody.innerHTML = "";

  teams.forEach((team) => {
    // Populate team table
    const teamRow = document.createElement("tr");
    const teamCell = document.createElement("td");
    teamCell.textContent = team.team;
    teamRow.appendChild(teamCell);
    teamTableBody.appendChild(teamRow);

    // Populate student table
    team.members.forEach((member) => {
      const studentRow = document.createElement("tr");

      const nameCell = document.createElement("td");
      nameCell.textContent = member.name;

      const teamCell = document.createElement("td");
      teamCell.textContent = team.team;

      const descriptionCell = document.createElement("td");
      descriptionCell.textContent = member.description;

      studentRow.appendChild(nameCell);
      studentRow.appendChild(teamCell);
      studentRow.appendChild(descriptionCell);

      studentTableBody.appendChild(studentRow);
    });
  });
}
