const getContact = async (id) => {
    return await fetch(`https://localhost:5001/Contacts/${id}`);
};

const getContacts = async () => {
    let response = await fetch("https://localhost:5001/Contacts");
    return await response.json();
};

const createContact = async (contact) => {
    return await fetch(`https://localhost:5001/Contacts`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(contact),
    });
};

const updateContact = async (id, contact) => {
    return await fetch(`https://localhost:5001/Contacts/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(contact),
    });
};

export { getContact, getContacts, updateContact, createContact };
