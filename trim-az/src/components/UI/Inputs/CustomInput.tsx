type PropsType = {
    type?: string;
    placeholder?: string;
    value?: any;
    className?: string;
};

const CustomInput = (props: PropsType) => (
    <input
        className={`custom_input ${props.className ?? ""}`}
        type={props.type ?? "text"}
        placeholder={props.placeholder ?? ""}
        value={props.value ?? ""}
    />
);

export default CustomInput;
