type PropsType = {
    className?: string;
    img: {
        src: any;
        alt?: string;
    };
};

const SquareImage = (props: PropsType) => (
<div className={`square_image ${props.className ?? ""}`}>
        <img
            src={props.img.src}
            alt={props.img.alt??'Illustration'}
        />
    </div>
);

export default SquareImage;
