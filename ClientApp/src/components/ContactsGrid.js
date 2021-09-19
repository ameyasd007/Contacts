import React, { useEffect, useState } from 'react'
import { getContacts } from '../services/ContactsService';
import ContactsRow from './ContactsRow';

export default function ContactGrid() {

    const [contactsData, setContactsData] = useState([]);

    useEffect(() => {
        let fetchContacts = async () => {
            let contacts = await getContacts();
            setContactsData(contacts);
        };
        fetchContacts();
    }, []);

    return (
        <div>
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Name </th>
                        <th>Email</th>
                        <th>Phone Number</th>
                        <th>Gender</th>
                        <th>Status</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {contactsData.map(contact => <ContactsRow key={contact.id} contact={contact} />)}
                </tbody>
            </table>
        </div>
    )
}
