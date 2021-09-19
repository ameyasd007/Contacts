import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import { FormGroup, Input, Label } from "reactstrap";
import { createContact, getContact, updateContact } from '../services/ContactsService';

export default function ContactsForm() {
    const id = new URLSearchParams(window.location.search).get("id");
    const { register, handleSubmit, reset } = useForm();

    useEffect(() => {
        const fetchContactDataForEditing = async () => {
            if (!id) return;
            let response = await getContact(id);
            console.log(response);
            if (response.status === 200) {
                let contactData = await response.json();
                console.log(contactData);

                reset(contactData);
            }
        };

        fetchContactDataForEditing();
    }, [id, reset]);

    const onSubmit = async (data) => {
        console.log(data);
        let response;
        if (id) {
            response = await updateContact(id, data);
            let contact = await response.json();
            if (response.status >= 200 && response.status <= 299) {
                reset(contact);
                alert("Contact Saved");
            } else {
                let errorMessage = await response.json();
                console.log(errorMessage);
                alert(JSON.stringify(errorMessage));
            }
        }
        else {
            response = await createContact({
                ...data,
                id: 0,
            });
            if (response.status >= 200 && response.status <= 299) {
                reset();
                alert("Contact Added");
            }
        }


    };

    return (
        <div>
            <form onSubmit={handleSubmit(onSubmit)}>
                <FormGroup>
                    <Label> First Name: </Label>
                    <input className="form-control" type="text" {...register("firstName")} />
                </FormGroup>
                <FormGroup>
                    <Label>Last Name:</Label>
                    <input className="form-control" type="text" {...register("lastName")} />
                </FormGroup>
                <FormGroup>
                    <Label>Email:</Label>
                    <input className="form-control" type="text" {...register("email")} />
                </FormGroup>
                <FormGroup>
                    <Label>Phone Number:</Label>
                    <input className="form-control" type="text" {...register("phoneNumber")} />
                </FormGroup>
                <FormGroup>
                    <Label>Gender:</Label>
                    <select className="form-control" {...register("gender")}>
                        <option value="">Select Gender</option>
                        <option value="Female">Female</option>
                        <option value="Male">Male</option>
                    </select>
                </FormGroup>
                <FormGroup>
                    <Label>Status:</Label>
                    <select className="form-control" {...register("status")}>
                        <option value="">Select Status</option>
                        <option value="Active">Active</option>
                        <option value="Inactive">Inactive</option>
                    </select>
                </FormGroup>

                <input type="text" hidden {...register("id")} />

                <br></br>
                <input className="form-control" type="submit" value="Save" style={{ background: "lightGrey" }} />
            </form>
        </div>
    )
}
