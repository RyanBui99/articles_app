import React, { useState } from 'react';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import ILoginRegister from '../../interfaces/ILoginRegister';
import NavbarComponent from '../../components/NavbarComponent';
import { useNavigate } from 'react-router-dom';
import { APIService } from '../../helpers/APIService';
import Authentication from '../../helpers/Authentication';
import SnackbarComponent from '../../components/SnackbarComponent';
import { AlertColor } from '@mui/material';

export default function LoginPage() {
  const navigate = useNavigate();
  const [open, setOpen] = useState(false);
  const [message, setMessage] = useState('');
  const [severity, setSeverity] = useState<AlertColor>();

  const handleClick = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const data = new FormData(e.currentTarget);
    const loginData: ILoginRegister = {
      username: data.get('username')!.toString(),
      password: data.get('password')!.toString(),
    };
    try {
      const response = await APIService.login(loginData);
      const { username, id, role } = response.data;
      Authentication.setUser({ username, id, role });
      setSeverity('success');
      navigate('/');
    } catch (error: any) {
      setSeverity('error');
      setMessage(error.response.data.message);
    }
  };

  return (
    <>
      <NavbarComponent />
      <Container
        component='main'
        maxWidth='xs'
        className='login_page'
        sx={{
          display: 'flex',
          justifyContent: 'center',
          alignItems: 'center',
          height: '90vh',
        }}
      >
        <SnackbarComponent
          open={open}
          handleClose={handleClose}
          message={message}
          severity={severity}
        />
        <Box
          sx={{
            display: 'flex',
            justifyContent: 'center',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <Typography component='h1' variant='h5'>
            Log in
          </Typography>
          <Box
            component='form'
            onSubmit={handleSubmit}
            noValidate
            sx={{ mt: 1 }}
          >
            <TextField
              margin='normal'
              required
              fullWidth
              id='username'
              label='Username'
              name='username'
              autoComplete='username'
              autoFocus
            />
            <TextField
              margin='normal'
              required
              fullWidth
              name='password'
              label='Password'
              type='password'
              id='password'
              autoComplete='current-password'
            />
            <Button
              type='submit'
              fullWidth
              variant='contained'
              sx={{ mt: 3, mb: 2 }}
              onClick={handleClick}
            >
              Sign In
            </Button>
          </Box>
        </Box>
      </Container>
    </>
  );
}
