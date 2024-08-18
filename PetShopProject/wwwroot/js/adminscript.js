let openForms = [];

function confirmSubmission() {
    const fileInput = document.getElementById('PictureName');
    const file = fileInput.files[0];
    if (file) {
        const allowedExtensions = ['.png', '.jpeg', '.jpg', '.webp'];
        const fileExtension = file.name.split('.').pop().toLowerCase();
        if (!allowedExtensions.includes(`.${fileExtension}`)) {
            alert("The file extension must be PNG, JPEG, JPG, or WEBP.");
            return false;
        }
        return true;
    }
    alert("Please select a file.");
    return false;
}

function confirmEdit(form) {
    const fileInput = form.querySelector('input[name="PictureName"]');
    const file = fileInput.files[0];
    if (file) {
        const allowedExtensions = ['.png', '.jpeg', '.jpg', '.webp'];
        const fileExtension = file.name.split('.').pop().toLowerCase();
        if (!allowedExtensions.includes(`.${fileExtension}`)) {
            alert("The file extension must be PNG, JPEG, JPG, or WEBP.");
            return false;
        }
        return true;
    }
    return true;
}


function handleEditClick(animalJson) {
    const data = animalJson.getAttribute('data-animal');
    const animal = JSON.parse(data);
    const existingForm = openForms[animal.animalId];
    if (existingForm) {
        return;
    }
    const categoriesString = animalJson.getAttribute('data-categories');
    const categories = JSON.parse(categoriesString);
    const infoContainer = document.createElement('div');
    infoContainer.className = 'infoContainer';
    
    const form = document.createElement('form');
    form.setAttribute('method', 'post');
    form.setAttribute('enctype', 'multipart/form-data');
    form.setAttribute('action', '/Admin/Edit');
    form.setAttribute('onsubmit', 'return confirmEdit(this)')

    form.innerHTML = `
        <h2>${animal.Name}</h2>
        <table>
            <tr>
                <td><label for="Name">Animal Name</label></td>
                <td><input type="text" id="Name" name="Name" value="${animal.Name}" required maxlength="50" /></td>
            </tr>
            <tr>
                <td><label for="Age">Age</label></td>
                <td><input type="number" id="Age" name="Age" value="${animal.Age}" required min="1" /></td>
            </tr>
            <tr>
                <td><label for="Category">Category</label></td>
                <td>
                    <select name="categoryId" required>
                        <!-- Populate categories dynamically -->
                        ${categories.map(category => `
                            <option value="${category.CategoryId}" ${animal.CategoryId === category.CategoryId ? 'selected' : ''}>
                                ${category.Name}
                            </option>
                        `).join('')}
                    </select>
                </td>
            </tr>
            <tr>
                <td><label for="PictureName">Picture Name</label></td>
                <td><input type="file" id="PictureName" name="PictureName" accept=".png, .jpg, .jpeg, .webp" /></td>
            </tr>
            <tr>
                <td><label for="Description">Description</label></td>
                <td><textarea id="Description" name="Description" required maxlength="10000">${animal.Description}</textarea></td>
            </tr>
            <tr>
                <input type="hidden" name="animalId" value="${animal.animalId}" />
                <td colspan="2">
                    <button type="submit">Insert</button>
                    <button type="button" onclick="closeForm(this)">Close</button>
                </td>
            </tr>
        </table>
    `;
    
    infoContainer.appendChild(form);
    const formContainer = document.getElementById('allAnimals');
    const animalContainer = animalJson.closest('.animalContainer');
    const referenceNode = animalContainer.nextSibling;
    formContainer.insertBefore(infoContainer, referenceNode);
    openForms[animal.animalId] = true;
}

// Function to close the form
function closeForm(button) {
    const infoContainer = button.closest('.infoContainer');
    const animalIdInput = infoContainer.querySelector('input[name="animalId"]');
    const animalId = animalIdInput.value;
    infoContainer.remove();
    openForms[animalId] = false;
}
