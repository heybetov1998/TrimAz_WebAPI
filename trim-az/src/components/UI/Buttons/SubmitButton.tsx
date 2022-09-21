type PropsType = {
    text: string;
    type?: "button" | "submit" | "reset" | undefined;
    className?: string;
};

const SubmitButton = (props: PropsType) => (
    <button
        type={props.type ?? "submit"}
        className={`submit_button ${props.className ?? ""}`}
    >
        {props.text}
    </button>
);

export default SubmitButton;
