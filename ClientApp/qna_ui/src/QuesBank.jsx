import React from "react";
import "./QuestionBank.css";
import { useState } from "react";

const QuesBank = (props) => {
    const [isExpanded, setExpanded] = useState(false);

    const [buttonName, setButtonname] = useState("Expand")

    const handleExpandClick = () => {
        setExpanded(!isExpanded); 
        if (buttonName == "Expand"){
            setButtonname("Collapse");
        }
    };
    return (
        <>
        <div className="card">
            <div className="card-body">
                <h5 className="card-title">Question {props.id}</h5>
                <p className="card-text">{props.ques}</p>
                {isExpanded && (
                    <div>
                    <p>{props.ans}</p>
                    </div>
                )}
                <button className="btn btn-primary" onClick={handleExpandClick}>{buttonName}</button>
            </div>
        </div>
        </>
    )
}

export default QuesBank;