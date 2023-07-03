import React, { ForwardedRef } from 'react'
import { FieldError, FieldErrorsImpl, FieldValues, Merge, UseFormRegister, UseFormRegisterReturn } from 'react-hook-form';

interface FormTextFieldProps {
    label : string;
    name: keyof FieldValues;
    register: any;
    error: FieldError | undefined;
}

const FormTextField = ( { label, name, register, error }:FormTextFieldProps ) => {
    return (
        <div>
            <label htmlFor={name}>{label}</label>
            <input {...register} type='text' name={name}/>
            {error && <span>{error.message?.toString()}</span>}
        </div>
    )
}

export default FormTextField