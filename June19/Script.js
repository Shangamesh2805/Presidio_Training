const quotesPerPage = 5;
let currentPage = 1;
let totalQuotes = 0;
let currentQuotes = [];
let filteredQuotes = [];

async function fetchQuotes(skip = 0, limit = quotesPerPage) {
    const response = await fetch(`https://dummyjson.com/quotes?limit=${limit}&skip=${skip}`);
    const data = await response.json();
    totalQuotes = data.total;
    return data.quotes;
}

function renderQuotes(quotes) {
    const quoteContainer = document.getElementById('quote-container');
    quoteContainer.innerHTML = '';

    quotes.forEach(quote => {
        const quoteElement = document.createElement('div');
        quoteElement.classList.add('col-md-4', 'quote');
        quoteElement.innerHTML = `
            <blockquote class="blockquote mb-0">
                <p><em>"${quote.quote}"</em></p>
                <footer class="blockquote-footer"><strong>${quote.author}</strong></footer>
            </blockquote>
        `;
        quoteContainer.appendChild(quoteElement);
    });
}

function renderPagination(totalPages) {
    const pagination = document.getElementById('pagination');
    pagination.innerHTML = '';

    const prevItem = document.createElement('button');
    prevItem.textContent = 'Previous';
    prevItem.disabled = currentPage === 1;
    prevItem.addEventListener('click', () => {
        if (currentPage > 1) {
            currentPage--;
            updateQuotes();
        }
    });
    pagination.appendChild(prevItem);

    const nextItem = document.createElement('button');
    nextItem.textContent = 'Next';
    nextItem.disabled = currentPage === totalPages;
    nextItem.addEventListener('click', () => {
        if (currentPage < totalPages) {
            currentPage++;
            updateQuotes();
        }
    });
    pagination.appendChild(nextItem);
}

async function updateQuotes() {
    const skip = (currentPage - 1) * quotesPerPage;
    const quotes = await fetchQuotes(skip, quotesPerPage);
    currentQuotes = quotes;
    renderQuotes(quotes);
    const totalPages = Math.ceil(totalQuotes / quotesPerPage);
    renderPagination(totalPages);
}

async function findQuote(authorName) {
    try {
        const response = await fetch(`https://dummyjson.com/quotes?limit=1454`);
        const data = await response.json();
        
        const quotes = data.quotes;
        filteredQuotes = quotes.filter(quote => quote.author.toLowerCase().includes(authorName.toLowerCase()));
        currentPage = 1;
        displayQuotes(filteredQuotes.slice(0, quotesPerPage));
        const totalPages = Math.ceil(filteredQuotes.length / quotesPerPage);
        renderPaginationForSearch(totalPages);
    } catch (error) {
        console.error('Error fetching quotes:', error);
    }
}

function displayQuotes(quotes) {
    const quoteContainer = document.getElementById('quote-container');
    quoteContainer.innerHTML = '';
    const pagination = document.getElementById('pagination');
    pagination.innerHTML = '';

    if (quotes.length == 0) {
        quoteContainer.innerHTML = '<p>No quotes found for this author.</p>';
        return;
    }

    quotes.forEach(quote => {
        const quoteElement = document.createElement('div');
        quoteElement.classList.add('col-md-4', 'quote');
        quoteElement.innerHTML = `
            <blockquote class="blockquote mb-0">
                <p>${quote.quote}</p>
                <footer class="blockquote-footer">${quote.author}</footer>
            </blockquote>
        `;
        quoteContainer.appendChild(quoteElement);
    });
}

function renderPaginationForSearch(totalPages) {
    const pagination = document.getElementById('pagination');
    pagination.innerHTML = '';

    const prevItem = document.createElement('button');
    prevItem.textContent = 'Previous';
    prevItem.disabled = currentPage === 1;
    prevItem.addEventListener('click', () => {
        if (currentPage > 1) {
            currentPage--;
            displayQuotes(filteredQuotes.slice((currentPage - 1) * quotesPerPage, currentPage * quotesPerPage));
        }
    });
    pagination.appendChild(prevItem);

    const nextItem = document.createElement('button');
    nextItem.textContent = 'Next';
    nextItem.disabled = currentPage === totalPages;
    nextItem.addEventListener('click', () => {
        if (currentPage < totalPages) {
            currentPage++;
            displayQuotes(filteredQuotes.slice((currentPage - 1) * quotesPerPage, currentPage * quotesPerPage));
        }
    });
    pagination.appendChild(nextItem);
}

document.getElementById('search-input').addEventListener('input', async function() {
    const authorName = this.value.trim();
    if (authorName.length === 0) {
        updateQuotes();
        return;
    }
    await findQuote(authorName);
});

function sortQuotesAscending() {
    currentQuotes.sort((a, b) => a.author.toLowerCase().localeCompare(b.author.toLowerCase()));
    displayQuotes(currentQuotes.slice((currentPage - 1) * quotesPerPage, currentPage * quotesPerPage));
}

function sortQuotesDescending() {
    currentQuotes.sort((a, b) => b.author.toLowerCase().localeCompare(a.author.toLowerCase()));
    displayQuotes(currentQuotes.slice((currentPage - 1) * quotesPerPage, currentPage * quotesPerPage));
}

function showHome() {
    const contentDiv = document.querySelector('.content');
    contentDiv.innerHTML = `
        <div class="welcome">
            <h1>Welcome to the Quotes Project</h1>
            <p>This project showcases a collection of inspirational quotes. Navigate to the Quotes page to view them!</p>
        </div>
    `;
}

function showQuotes() {
    const contentDiv = document.querySelector('.content');
    contentDiv.innerHTML = `
        <div class="search-bar">
            <input type="text" id="search-input" placeholder="Search by author">
            <button onclick="sortQuotesAscending()">Sort Ascending</button>
            <button onclick="sortQuotesDescending()">Sort Descending</button>
        </div>
        <div id="quote-container" class="row"></div>
        <ul id="pagination" class="pagination"></ul>
    `;
    updateQuotes();
}

showHome();
