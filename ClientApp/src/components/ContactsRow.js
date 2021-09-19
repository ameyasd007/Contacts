import React from 'react'

export default function ContactsRow({ contact }) {
    return (
        <tr>
            <td>{contact.fullName}</td>
            <td>{contact.email}</td>
            <td>{contact.phoneNumber}</td>
            <td>{contact.gender}</td>
            <td>{contact.status}</td>
            <td>
                <a href={`/contact?id=${contact.id}`}>Edit</a>
            </td>
        </tr>
    )
}
