document.getElementById('wordBankForm').addEventListener('submit', async function(event) {
    event.preventDefault();

    const formData = new FormData(event.target);
    const params = new URLSearchParams();

    for (const [key, value] of formData.entries()) {
        if (value) {
            params.append(key, value);
        }
    }

    const response = await fetch(`/wordbank?${params.toString()}`);
    const wordBank = await response.json();

    const wordBankResult = document.getElementById('wordBankResult');
    wordBankResult.innerHTML = '';

    if (wordBank.length > 0) {
        const ul = document.createElement('ul');
        wordBank.forEach(word => {
            const li = document.createElement('li');
            li.textContent = word;
            ul.appendChild(li);
        });
        wordBankResult.appendChild(ul);
    } else {
        wordBankResult.textContent = 'No words found matching the criteria.';
    }
});
