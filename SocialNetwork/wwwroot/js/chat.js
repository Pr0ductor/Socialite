let connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .withAutomaticReconnect()
    .build();

// Подключение к чату
connection.start().then(function () {
    console.log("SignalR Connected!");
    // Присоединяемся к группе чата
    const userId = document.getElementById("currentUserId").value;
    connection.invoke("JoinChat", userId);
}).catch(function (err) {
    console.error(err.toString());
});

// Обработка получения нового сообщения
connection.on("ReceiveMessage", function (senderId, receiverId, content) {
    const currentUserId = document.getElementById("currentUserId").value;
    
    // Если сообщение для текущего пользователя
    if (receiverId === currentUserId || senderId === currentUserId) {
        // Добавляем сообщение в чат
        const chatContainer = document.querySelector(".chat-messages");
        const messageDiv = document.createElement("div");
        messageDiv.className = `message ${senderId === currentUserId ? "message-out" : "message-in"}`;
        
        messageDiv.innerHTML = `
            <div class="message-content">
                <div class="message-text">${content}</div>
                <div class="message-time">${new Date().toLocaleTimeString()}</div>
            </div>
        `;
        
        chatContainer.appendChild(messageDiv);
        chatContainer.scrollTop = chatContainer.scrollHeight;
    }
});

// Функция отправки сообщения
async function sendMessage(receiverId) {
    const content = document.getElementById("messageInput").value;
    if (!content) return;

    try {
        const response = await fetch("/Messages/SendMessage", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                receiverId: receiverId,
                content: content
            })
        });

        if (response.ok) {
            document.getElementById("messageInput").value = "";
        }
    } catch (error) {
        console.error("Error sending message:", error);
    }
}

// Обработчик отправки сообщения
document.getElementById("sendMessageBtn").addEventListener("click", function() {
    const receiverId = document.getElementById("currentReceiverId").value;
    sendMessage(receiverId);
});

// Обработка нажатия Enter в поле ввода
document.getElementById("messageInput").addEventListener("keypress", function(e) {
    if (e.key === "Enter") {
        const receiverId = document.getElementById("currentReceiverId").value;
        sendMessage(receiverId);
    }
}); 