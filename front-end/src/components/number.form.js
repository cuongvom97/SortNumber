import React, { useState } from 'react';
import '../components/number.form.css';
import axios from 'axios';
import url from '../config';

function ArrNumber() {
    const [number, setNumber] = useState('');
    const [numberErr, setNumberErr] = useState(false);
    const validNumber = new RegExp('^[0-9]+(,[0-9]+)*$');
    const [finalResult, setResult] = useState("");

    const handleChange = (e) => {
        e.preventDefault();
        setNumber(e.target.value);
        setResult('')
        if (!validNumber.test(e.target.value)) {
            setNumberErr(true);
        }
        else {
            setNumberErr(false);
        }
        console.log(validNumber.test(e.target.value));
        console.log(numberErr);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        axios.post(`${url.sortUrl}?number=${number}`)
            .then(res => {
                if (res.status <= 300) {
                    setNumber('');
                    setNumberErr(false);
                    setResult(res.data);
                }
            })
            .catch(err => console.log(err));
    }
    return (
        <form className='my-form' onSubmit={handleSubmit}>
            <div>
                <input value={number} name='number' placeholder='Enter your input >=30 digits (1,2,...)' onChange={(e) => {
                    handleChange(e);
                }} />
                {numberErr && <div className='err-message'>Input should be &gt;=30 digits (1,2,...)</div>}
                {finalResult !== undefined && finalResult !== "" && <p>Here is result:{finalResult}</p>}
            </div>
            <div>
                <button type='button' onClick={(e) => { handleSubmit(e) }} disabled={!validNumber.test(number)}>Submit</button>
            </div>
        </form>
    );
}

export default ArrNumber;