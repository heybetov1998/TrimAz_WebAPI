import ContactInput from "./ContactInput";

type PropsType = {
    name?: string;
    inputId?: string;
    inputType?: string;
    inputValue?: string | number;
};

const InputBlock = (props: PropsType) => (
    <div className="input_block">
        {props.name && (
            <label htmlFor={props.inputId ?? ""}>{props.name}</label>
        )}
        <ContactInput
            id={props.inputId ?? ""}
            type={props.inputType ?? "text"}
            value={props.inputValue ?? ""}
        />
    </div>
);

export default InputBlock;
