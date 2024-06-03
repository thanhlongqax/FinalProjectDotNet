import React from "react";
import {
    Navbar,
    MobileNav,
    Typography,
    Button,
    Menu,
    MenuHandler,
    MenuList,
    MenuItem,
    Avatar,
    IconButton,
    Input,
} from "@material-tailwind/react";
import {
    UserCircleIcon,
    ChevronDownIcon,
    Cog6ToothIcon,
    InboxArrowDownIcon,
    LifebuoyIcon,
    PowerIcon,
    Bars2Icon,
    GlobeAltIcon,
    BellIcon,
    ChatBubbleLeftIcon
} from "@heroicons/react/24/solid";
import image from '../../../assets/img/admin/user/user-01.png';

// profile menu component
const profileMenuItems = [
    {
        label: "Cá nhân",
        icon: UserCircleIcon,
    },
    {
        label: "Chỉnh sửa",
        icon: Cog6ToothIcon,
    },
    {
        label: "Tin nhắn",
        icon: InboxArrowDownIcon,
    },
    {
        label: "Trợ giúp",
        icon: LifebuoyIcon,
    },
    {
        label: "Đăng xuất",
        icon: PowerIcon,
    },
];

function ProfileMenu() {
    const [isMenuOpen, setIsMenuOpen] = React.useState(false);

    const closeMenu = () => setIsMenuOpen(false);

    return (
        <Menu open={isMenuOpen} handler={setIsMenuOpen} placement="bottom-end">
            <MenuHandler>
                <Button
                    variant="text"
                    color="blue-gray"
                    className="flex items-center gap-1 rounded-full py-0.5 pr-2 pl-0.5 lg:ml-auto"
                >
                    <Avatar
                        variant="circular"
                        size="sm"
                        alt="tania andrew"
                        className="border border-gray-900 p-0.5"
                        src={image}
                    />
                    <ChevronDownIcon
                        strokeWidth={2.5}
                        className={`h-3 w-3 transition-transform ${isMenuOpen ? "rotate-180" : ""
                            }`}
                    />
                </Button>
            </MenuHandler>
            <MenuList className="p-1">
                {profileMenuItems.map(({ label, icon }, key) => {
                    const isLastItem = key === profileMenuItems.length - 1;
                    return (
                        <MenuItem
                            key={label}
                            onClick={closeMenu}
                            className={`flex items-center gap-2 rounded ${isLastItem
                                ? "hover:bg-red-500/10 focus:bg-red-500/10 active:bg-red-500/10"
                                : ""
                                }`}
                        >
                            {React.createElement(icon, {
                                className: `h-4 w-4 ${isLastItem ? "text-red-500" : ""}`,
                                strokeWidth: 2,
                            })}
                            <Typography
                                as="span"
                                variant="small"
                                className="font-normal"
                                color={isLastItem ? "red" : "inherit"}
                            >
                                {label}
                            </Typography>
                        </MenuItem>
                    );
                })}
            </MenuList>
        </Menu>
    );
}




// nav list component
const navListItems = [
    {
        label: "Vietnam",
        icon: GlobeAltIcon,
    },
    {
        label: "Thông báo",
        icon: BellIcon,
    },
    {
        label: "Tin nhắn",
        icon: ChatBubbleLeftIcon,
    },
];

function NavList() {
    return (
        <ul className="mt-2 mb-4 flex flex-col gap-2 lg:mb-0 lg:mt-0 lg:flex-row lg:items-center">

            {navListItems.map(({ label, icon }, key) => (
                <Typography
                    key={label}
                    as="a"
                    href="#"
                    variant="small"
                    color="gray"
                    className="font-medium text-blue-gray-500"
                >
                    <MenuItem className="flex items-center gap-2 lg:rounded-full">
                        {React.createElement(icon, { className: "h-[18px] w-[18px]" })}{" "}
                        <span className="text-gray-900"> {label}</span>
                    </MenuItem>
                </Typography>
            ))}
        </ul>
    );
}

export function Header() {
    const [isNavOpen, setIsNavOpen] = React.useState(false);

    const toggleIsNavOpen = () => setIsNavOpen((cur) => !cur);

    React.useEffect(() => {
        window.addEventListener(
            "resize",
            () => window.innerWidth >= 960 && setIsNavOpen(false),
        );
    }, []);

    return (
        <Navbar className="mx-auto max-w-screen-2xl p-2 bg-white lg:rounded-md lg:pl-6">
            <div className="relative mx-auto md:w-[600px] lg:w-[1040px] flex items-center justify-between text-blue-gray-900">
                <div className="relative flex w-full gap-2 md:w-max">
                    <Input
                        type="search"
                        color="blue-gray"
                        label="Type here..."
                        className="pr-20"
                        containerProps={{
                            className: "min-w-[288px]",
                        }}
                    />
                    <Button
                        size="sm"
                        color="blue-gray"
                        className="!absolute right-1 top-1 rounded  bg-accent"
                    >
                        Tìm kiếm
                    </Button>
                </div>
                <div className=" flex flex-row">
                    <div className="hidden lg:block">
                        <NavList />
                    </div>
                    <IconButton
                        size="sm"
                        color="blue-gray"
                        variant="text"
                        onClick={toggleIsNavOpen}
                        className="ml-auto mr-2 lg:hidden"
                    >
                        <Bars2Icon className="h-6 w-6" />
                    </IconButton>
                    <ProfileMenu />
                </div>
            </div>
            <MobileNav open={isNavOpen} className="overflow-scroll">
                <NavList />
            </MobileNav>
        </Navbar>
    );
}

export default Header;