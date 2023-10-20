import React, { useState } from "react";

const AddQues = () => {    

    const [formData, setFormData] = useState({
        companyName: '',
        question: '',
        answer: '',
    });

    const HandleChange = (event) => {
        const {name, value} = event.target;
        setFormData({...formData, [name] : value});
        
    };
    
     const HandleSubmit = async (event) => {       
        event.preventDefault();
        
        const response = await fetch('https://localhost:7145/api/QNAs', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=UTF-8',
            },
            body: JSON.stringify(formData),
        });

        if (response.ok){
            alert("Message saved successfully!");
            window.location.reload();
        }
        else{
            console.error('Error sending POST request');
        }
    }

    return(
        <>
            <form onSubmit={HandleSubmit}>
                <div className="form-group">
                    <label htmlFor="companyName">Company name</label>
                    <input type="text" className="form-control" id="companyName" name='companyName' value={formData.companyName} onChange= {HandleChange} placeholder="Rovers Compass"/>
                </div><div className="form-group">
                <label htmlFor="questions">Questions</label>
                    <input type="text" className="form-control" id="questions" name='question' value={formData.question} onChange= {HandleChange} placeholder="Whats your name?"/>
                </div>
                <div className="form-group">
                    <label htmlFor="answers">Answer</label>
                    <textarea className="form-control" id="answers" name='answer' value={formData.answer} onChange= {HandleChange} rows="3"></textarea>
                </div>
                <button type="submit" className="btn btn-primary">Submit</button>
            </form>
        </>
    );
}

export default AddQues;