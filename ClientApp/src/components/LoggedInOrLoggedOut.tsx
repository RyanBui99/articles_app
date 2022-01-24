import Box from '@mui/material/Box';
import IconButton from '@mui/material/IconButton';
import Menu from '@mui/material/Menu';
import Avatar from '@mui/material/Avatar';
import Tooltip from '@mui/material/Tooltip';
import MenuItem from '@mui/material/MenuItem';
import MenuIcon from '@mui/icons-material/Menu';
import React from 'react';
import Authentication from '../helpers/Authentication';
import { navbarLinks } from '../constants/navbarLinks';
import { useNavigate } from 'react-router-dom';
import { Button } from '@material-ui/core';
import CreateBlogPostModal from './modals/CreateBlogPostModal';

export default function LoggedInOrLoggedOut(props: any) {
  const user = Authentication.getUser();
  const navigate = useNavigate();
  const [open, setOpen] = React.useState(false);

  const handleClickOpen = () => {
    props.handleCloseMenu()
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const logout = () => {
    Authentication.logoutUser();
    navigate('/');
  };

  const AdminOrUser = () => {
    if (user.role == 'admin') {
      return (
        <>
          {navbarLinks.adminLinks.map((link: any, key: number) => (
            <MenuItem component={link.component} to={link.link} key={key}>
              {link.linkName}
            </MenuItem>
          ))}
        </>
      );
    }
    return <></>;
  };

  if (user.username != 'null') {
    return (
      <Box>
        <Tooltip title='Open settings'>
          <IconButton onClick={props.handleOpenMenu}>
            <Avatar alt={user.username} src='/static/images/avatar/2.jpg' />
          </IconButton>
        </Tooltip>
        <Menu
          sx={{ mt: '45px' }}
          id='menu-appbar'
          anchorEl={props.anchorNav}
          anchorOrigin={{
            vertical: 'top',
            horizontal: 'right',
          }}
          keepMounted
          transformOrigin={{
            vertical: 'top',
            horizontal: 'right',
          }}
          open={Boolean(props.anchorNav)}
          onClose={props.handleCloseMenu}
        >
          <MenuItem onClick={handleClickOpen}>Write a post</MenuItem>
          <AdminOrUser />
          {/* <MenuItem onClick={logout}>Log out</MenuItem> */}
        </Menu>
        <CreateBlogPostModal handleclose={handleClose} open={open} />
      </Box>
    );
  } else {
    return (
      <>
        <Box sx={{ flexGrow: 0, display: { xs: 'flex', md: 'none' } }}>
          <IconButton
            size='large'
            aria-label='nav-links'
            aria-controls='menu-appbar'
            aria-haspopup='true'
            onClick={props.handleOpenMenu}
            color='inherit'
          >
            <MenuIcon fontSize='large' />
          </IconButton>
          <Menu
            id='menu-appbar'
            anchorEl={props.anchorNav}
            anchorOrigin={{
              vertical: 'top',
              horizontal: 'right',
            }}
            keepMounted
            transformOrigin={{
              vertical: 'top',
              horizontal: 'right',
            }}
            open={Boolean(props.anchorNav)}
            onClose={props.handleCloseMenu}
            sx={{ mt: '40px' }}
          >
            {navbarLinks.navLinks.map((link: any, key: number) => (
              <MenuItem component={link.component} to={link.link} key={key}>
                {link.linkName}
              </MenuItem>
            ))}
          </Menu>
        </Box>

        <Box sx={{ flexGrow: 0, display: { xs: 'none', md: 'flex' } }}>
          {navbarLinks.navLinks.map((link: any, key: number) => (
            <MenuItem component={link.component} to={link.link} key={key}>
              {link.linkName}
            </MenuItem>
          ))}
        </Box>
      </>
    );
  }
}
