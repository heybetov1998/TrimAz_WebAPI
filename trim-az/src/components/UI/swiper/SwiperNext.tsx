import { BiRightArrowAlt } from "react-icons/bi";

interface Props {
    className?: string;
}

const SwiperNext = (props: Props) => (
    <div
        className={`d-flex justify-content-center align-items-center swiper-custom-next ${props.className}`}
    >
        <BiRightArrowAlt size={"1.5rem"} />
    </div>
);

export default SwiperNext;
