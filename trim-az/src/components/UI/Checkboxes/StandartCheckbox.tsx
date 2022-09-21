import { useState } from "react";
import { BiCheck } from "react-icons/bi";

type PropsType = {
    text: string;
    isDisabled?: boolean;
    isChecked?: boolean;
};

const StandartCheckbox = (props: PropsType) => {
    const [isChecked, setIsChecked] = useState(props.isChecked);

    const checkHandler = () => setIsChecked((prevState) => !prevState);

    return (
        <label>
            <input
                type="checkbox"
                onChange={checkHandler}
                disabled={props.isDisabled}
            />
            <span
                className={`standart_checkbox ${
                    isChecked ? "checkbox-active" : ""
                }`}
                aria-hidden="true"
            >
                {isChecked && <BiCheck size={"2rem"} />}
            </span>
            {props.text}
        </label>
    );
};

export default StandartCheckbox;
