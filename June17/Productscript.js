document.addEventListener("DOMContentLoaded", function() {
    fetch('https://dummyjson.com/products')
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            const productContainer = document.getElementById('product-container');
            if (data.products && data.products.length > 0) {
                data.products.forEach(product => {
                    const productCard = document.createElement('div');
                    productCard.className = 'col-md-4';
                    productCard.innerHTML = `
                        <div class="card product-card">
                            <img src="${product.thumbnail}" class="card-img-top" alt="${product.title}">
                            <div class="card-body">
                                <h5 class="card-title">${product.title}</h5>
                                <p class="card-text">${product.description.substring(0, 100)}...</p>
                                <p class="card-text"><strong>Price:</strong> $${product.price}</p>
                            </div>
                        </div>
                    `;
                    productContainer.appendChild(productCard);
                });
            } else {
                productContainer.innerHTML = '<p class="text-center">No products found.</p>';
            }
        })
        .catch(error => {
            console.error('Error fetching the products:', error);
            document.getElementById('product-container').innerHTML = `<p class="text-center text-danger">Error fetching the products: ${error.message}</p>`;
        });
});
