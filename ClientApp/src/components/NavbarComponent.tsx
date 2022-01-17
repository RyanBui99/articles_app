import React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import Menu from '@mui/material/Menu';
import Container from '@mui/material/Container';
import Avatar from '@mui/material/Avatar';
import Tooltip from '@mui/material/Tooltip';
import MenuItem from '@mui/material/MenuItem';
import CssBaseline from '@mui/material/CssBaseline';
import { Link } from 'react-router-dom';
import MenuIcon from '@mui/icons-material/Menu';

const settings = ['Dashboard', 'Logout'];
const navLinks = [
  {
    linkName: 'Log in',
    link: '/login',
    component: Link,
  },
  {
    linkName: 'Register',
    link: '/register',
    component: Link,
  },
];

export default function NavbarComponent() {
  const [anchorNav, setAnchorNav] = React.useState(null);
  const [user, setUser] = React.useState(null);

  const handleOpenMenu = (e: any) => {
    setAnchorNav(e.currentTarget);
  };

  const handleCloseMenu = () => {
    setAnchorNav(null);
  };

  /**
   * Different nav options depending on if
   * user is logged in or not
   */
  const LoggedInOrLoggedOut = () => {
    if (user != null) {
      return (
        <Box sx={{ flexGrow: 0 }}>
          <Tooltip title='Open settings'>
            <IconButton onClick={handleOpenMenu} sx={{ p: 0 }}>
              <Avatar alt='Admin' src='/static/images/avatar/2.jpg' />
            </IconButton>
          </Tooltip>
          <Menu
            sx={{ mt: '45px' }}
            id='menu-appbar'
            anchorEl={anchorNav}
            anchorOrigin={{
              vertical: 'top',
              horizontal: 'right',
            }}
            keepMounted
            transformOrigin={{
              vertical: 'top',
              horizontal: 'right',
            }}
            open={Boolean(anchorNav)} //anchorElUser
            onClose={handleCloseMenu}
          >
            {settings.map((setting) => (
              <MenuItem key={setting} onClick={handleCloseMenu}>
                <Typography textAlign='center'>{setting}</Typography>
              </MenuItem>
            ))}
          </Menu>
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
              onClick={handleOpenMenu}
              color='inherit'
            >
              <MenuIcon fontSize='large'/>
            </IconButton>
            <Menu
              id='menu-appbar'
              anchorEl={anchorNav}
              anchorOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              keepMounted
              transformOrigin={{
                vertical: 'top',
                horizontal: 'right',
              }}
              open={Boolean(anchorNav)}
              onClose={handleCloseMenu}
              sx={{ mt: '40px' }}
            >
              {navLinks.map((link, key) => (
                <MenuItem component={link.component} to={link.link} key={key}>
                  {link.linkName}
                </MenuItem>
              ))}
            </Menu>
          </Box>

          <Box sx={{ flexGrow: 0, display: { xs: 'none', md: 'flex' } }}>
            {navLinks.map((link, key) => (
              <MenuItem component={link.component} to={link.link} key={key}>
                {link.linkName}
              </MenuItem>
            ))}
          </Box>
        </>
      );
    }
  };

  return (
    <AppBar position='static'>
      <CssBaseline />
      <Container maxWidth='xl'>
        <Toolbar disableGutters>
          <Typography
            variant='h6'
            noWrap
            component='div'
            sx={{ flexGrow: 1, mr: 2, display: { xs: 'none', md: 'flex' } }}
          >
            <Link to='/' style={{textDecoration: 'none', color: 'inherit'}}>GigaBlog</Link>
          </Typography>
          <Typography
            variant='h6'
            noWrap
            component='div'
            sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}
          >
            <Link to='/' style={{textDecoration: 'none', color: 'inherit'}}>GigaBlog</Link>
          </Typography>
          <LoggedInOrLoggedOut />
        </Toolbar>
      </Container>
    </AppBar>
  );
}
