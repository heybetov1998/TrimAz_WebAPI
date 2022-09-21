type PropsType = {
    title?: string;
    className?: string;
    children: React.ReactNode;
};

const CardFrame = (props: PropsType) => {
    return (
        <div className={`card_frame ${props.className ?? ""}`}>
            {props.title && (
                <h3 className={`card_frame_title ${props.className ?? ""}`}>
                    {props.title}
                </h3>
            )}
            {props.children}
        </div>
    );
};

export default CardFrame;
