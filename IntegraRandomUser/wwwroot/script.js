const API_URL = "https://localhost:7169/api/v1/User"; // ajuste para a porta da sua API

async function carregarUsers() {
    const response = await fetch(`${API_URL}/db`);
    const users = await response.json();

    const tbody = document.querySelector("#userTable tbody");
    tbody.innerHTML = "";

    users.forEach(user => {
        const row = document.createElement("tr");

        row.innerHTML = `
      <td>${user.id}</td>
      <td><input type="text" value="${user.firstName}" data-field="firstName"></td>
      <td><input type="text" value="${user.lastName}" data-field="lastName"></td>
      <td><input type="text" value="${user.email}" data-field="email"></td>
      <td><input type="text" value="${user.username}" data-field="username"></td>
      <td><input type="text" value="${user.gender}" data-field="gender"></td>
      <td><input type="text" value="${user.city}" data-field="city"></td>
      <td><input type="text" value="${user.state}" data-field="state"></td>
      <td><input type="text" value="${user.country}" data-field="country"></td>
      <td>
        <button onclick="salvarUser(${user.id}, this)">Salvar</button>
      </td>
    `;

        tbody.appendChild(row);
    });
}

async function salvarUser(id, button) {
    const row = button.closest("tr");
    const inputs = row.querySelectorAll("input");

    const userAtualizado = {
        id: id
    };

    inputs.forEach(input => {
        userAtualizado[input.dataset.field] = input.value;
    });

    const response = await fetch(`${API_URL}/db/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(userAtualizado)
    });

    if (response.ok) {
        alert("User atualizado com sucesso!");
        carregarUsers();
    } else {
        alert("Erro ao atualizar User.");
    }
}

// carregar ao iniciar
carregarUsers();
