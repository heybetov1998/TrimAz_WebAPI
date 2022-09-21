import { Link } from "react-router-dom";

type PropsType = {
    author?: {
        id: string;
        image: {
            src: string;
            alt: string;
        };
        name: string;
    };
    createdDate?: string;
    className?: string;
};

const AuthorInfo = (props: PropsType) => {
    if (props.author) {
        return (
            <div className={`author_info ${props.className ?? ""}`}>
                <Link to={`/users/${props.author.id}`} className="author_pp">
                    <img
                        src={props.author.image.src}
                        alt={props.author.image.alt}
                    />
                </Link>
                <div className="d-flex align-items-center">
                    <Link
                        to={`/users/${props.author.id}`}
                        className="author_name"
                    >
                        {props.author.name}
                    </Link>
                    {props.createdDate && (
                        <span className="dateHolder">{props.createdDate}</span>
                    )}
                </div>
            </div>
        );
    }
    return <div></div>;
};

export default AuthorInfo;
