function deposit() {
    const userId = document.getElementById('userId').value;
    const accountId = document.getElementById('accountId').value;
    const amount = document.getElementById('amount').value;

    if (userId == "" || accountId == "" || amount == "") {
        document.getElementById('message').innerText = 'Error: Incomplete details';
        return;
    }

    const transaction = new Transaction(parseInt(userId), parseInt(accountId), parseInt(amount), 0)
    var validateError = validateInput(parseInt(amount), 0);
    if (validateError != null || validateError != undefined) {
        document.getElementById('message').innerText = 'Error: ' + validateError;
        return;
    }

    fetch('https://localhost:7056/transaction/deposit', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(transaction),
    })
        .then(response => {
                return response.text();
        })
        .then(data => {
            document.getElementById('message').innerText = data;
        })
        .catch((error) => {
            document.getElementById('message').innerText = 'Error: ' + error;
        });
}

function withdraw() {
    const userId = document.getElementById('userId').value;
    const accountId = document.getElementById('accountId').value;
    const amount = document.getElementById('amount').value;

    if (userId == "" || accountId == "" || amount == "") {
        document.getElementById('message').innerText = 'Error: Incomplete details';
        return;
    }

    const transaction = new Transaction(parseInt(userId), parseInt(accountId), parseInt(amount), 1)

    var validateError = validateInput(parseInt(amount), 1);
    if (validateError != null || validateError != undefined) {
        document.getElementById('message').innerText = 'Error: ' + validateError;
        return;
    }

    fetch('https://localhost:7056/transaction/withdraw', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(transaction),
    })
        .then(response => {
                return response.text();
        })
        .then(data => {

            document.getElementById('message').innerText = data;
        })
        .catch((error) => {
            document.getElementById('message').innerText = 'Error: ' + error;
        });
}

function deleteUser() {
    const userId = document.getElementById('userId').value;
    const accountId = document.getElementById('accountId').value;

    if (userId == "" || accountId == "") {
        document.getElementById('message').innerText = 'Error: Incomplete details';
        return;
    }

    var _userId = parseInt(userId);
    var _accountId = parseInt(accountId);

    fetch(`https://localhost:7056/userAccount/delete?userId=${userId}&accountId=${accountId}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
    })
        .then(response => {
                return response.text();
        })
        .then(data => {
            document.getElementById('message').innerText = data;;
        })
        .catch((error) => {
            document.getElementById('message').innerText = 'Error: ' + error;
        });
}

function validateInput(amount, type) {
    if (type == 0) {
        if (amount <= 0 || amount > 10000)
            return "Please enter valid amount. Deposit amount allowed between 1 to 10,000";
    }
    else if (type == 1) {
        if (amount <= 0)
            return "Please enter valid amount."

    }
    else
    return null;
}
