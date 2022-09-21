import { FaFacebookF, FaTwitter, FaInstagram, FaTiktok } from "react-icons/fa";

const Footer = () => {
    return (
        <footer>
            <div className="container d-flex justify-content-between">
                <p className="leftFooter">Copyright &copy; Trim.az. 2022</p>
                <ul className="rightFooter d-flex justify-content-end">
                    <li>
                        <a
                            href="https://facebook.com"
                            target="_blank"
                            rel="noreferrer"
                        >
                            <FaFacebookF size={"1.3rem"} />
                        </a>
                    </li>
                    <li>
                        <a
                            href="https://twitter.com"
                            target="_blank"
                            rel="noreferrer"
                        >
                            <FaTwitter size={"1.3rem"} />
                        </a>
                    </li>
                    <li>
                        <a
                            href="https://instagram.com"
                            target="_blank"
                            rel="noreferrer"
                        >
                            <FaInstagram size={"1.3rem"} />
                        </a>
                    </li>
                    <li>
                        <a
                            href="https://tiktok.com"
                            target="_blank"
                            rel="noreferrer"
                        >
                            <FaTiktok size={"1.3rem"} />
                        </a>
                    </li>
                </ul>
            </div>
        </footer>
    );
};

export default Footer;
