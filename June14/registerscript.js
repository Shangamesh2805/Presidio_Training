const professions = ["Engineer", "Doctor", "Teacher", "Accountant", "Pani puri shop owner"];

function addProfession() {
    const newProfession = document.getElementById("profession").value.trim();

    if (newProfession && !professions.includes(newProfession)) {
        professions.push(newProfession);
        const option = document.createElement("option");
        option.value = newProfession;
        document.getElementById("professions").appendChild(option);
    }
}

function validateAllFields() {
    const errors = [];

    const nameError = validateName();
    if (nameError) errors.push(nameError);

    const phoneError = validatePhone();
    if (phoneError) errors.push(phoneError);

    const emailError = validateEmail();
    if (emailError) errors.push(emailError);

    const dobError = validateDob();
    if (dobError) errors.push(dobError);

    return errors;
}

function buttonClick() {
    const myDiv = document.getElementById("buttondiv");
    addProfession();
    const errors = validateAllFields();
    myDiv.innerHTML = errors.join("<br>");
}

function validateName() {
    const txtName = document.getElementById("name");
    const errMsg = document.getElementById("errorMsgName");
    if (!txtName.value.trim()) {
        errMsg.innerHTML = "Name cannot be empty";
        txtName.classList.add("error");
        txtName.classList.remove("correct");
        return "Name cannot be empty";
    } else {
        errMsg.innerHTML = "";
        txtName.classList.remove("error");
        txtName.classList.add("correct");
    }
}

function validatePhone() {
    const txtPhone = document.getElementById("phone");
    const errMsg = document.getElementById("errorMsgPh");
    const phoneRegex = /^\d{10}$/;
    if (!txtPhone.value.trim()) {
        errMsg.innerHTML = "Phone cannot be empty";
        txtPhone.classList.add("error");
        txtPhone.classList.remove("correct");
        return "Phone cannot be empty";
    } else if (!phoneRegex.test(txtPhone.value.trim())) {
        errMsg.innerHTML = "Invalid entry for Phone";
        txtPhone.classList.add("error");
        txtPhone.classList.remove("correct");
        return "Invalid entry for Phone";
    } else {
        errMsg.innerHTML = "";
        txtPhone.classList.remove("error");
        txtPhone.classList.add("correct");
    }
}

function validateEmail() {
    const txtEmail = document.getElementById("email");
    const errMsg = document.getElementById("errorMsgEm");
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!txtEmail.value.trim()) {
        errMsg.innerHTML = "Email cannot be empty";
        txtEmail.classList.add("error");
        txtEmail.classList.remove("correct");
        return "Email cannot be empty";
    } else if (!emailRegex.test(txtEmail.value.trim())) {
        errMsg.innerHTML = "Invalid Email";
        txtEmail.classList.add("error");
        txtEmail.classList.remove("correct");
        return "Invalid Email";
    } else {
        errMsg.innerHTML = "";
        txtEmail.classList.remove("error");
        txtEmail.classList.add("correct");
    }
}

function validateDob() {
    const txtDob = document.getElementById("dob");
    const errMsg = document.getElementById("errorMsgDob");
    const ageInput = document.getElementById("age");

    if (!txtDob.value.trim()) {
        errMsg.innerHTML = "Date of Birth cannot be empty";
        txtDob.classList.add("error");
        txtDob.classList.remove("correct");
        return "Date of Birth cannot be empty";
    } else {
        errMsg.innerHTML = "";
        txtDob.classList.remove("error");
        txtDob.classList.add("correct");

        const dob = new Date(txtDob.value);
        const today = new Date();
        let age = today.getFullYear() - dob.getFullYear();
        const monthDiff = today.getMonth() - dob.getMonth();
        if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < dob.getDate())) {
            age--;
        }
        ageInput.value = age;
    }
}
