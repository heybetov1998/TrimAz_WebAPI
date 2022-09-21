import { BiLeftArrowAlt } from "react-icons/bi";

interface Props {
    className?: string;
}

const SwiperPrev = (props: Props) => (
    <div
        className={`d-flex justify-content-center align-items-center swiper-custom-prev ${props.className}`}
    >
        <BiLeftArrowAlt size={"1.5rem"} />
    </div>
);

export default SwiperPrev;
