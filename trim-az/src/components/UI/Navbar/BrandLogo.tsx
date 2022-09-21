import { Link } from "react-router-dom";
import brandLogo from "../../../assets/svg/brand-logo.svg";

const BrandLogo = () => {
    return (
        <div className="h-100 d-flex justify-content-start align-items-center">
            <Link to="/">
                <img className="brand_logo" src={brandLogo} alt="App logo" />
            </Link>
        </div>
    );
};

export default BrandLogo;
