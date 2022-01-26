import React, { useState } from 'react';
import Button from '@mui/material/Button';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import useMediaQuery from '@mui/material/useMediaQuery';
import { useTheme } from '@mui/material/styles';
import CloseIcon from '@mui/icons-material/Close';
import {
  Box,
  TextField,
  FormControl,
  FormControlLabel,
  FormLabel,
  Radio,
  RadioGroup,
  IconButton,
} from '@material-ui/core';
import SnackbarComponent from '../SnackbarComponent';
import IStorageUser from '../../interfaces/IStorageUser';
import { editUser } from '../../store/actionCreators/userCreator';
import { useDispatch } from 'react-redux';
import { AlertColor } from '@mui/material';

interface Prop {
  closeModal: () => void;
  isModalOpen: boolean;
  user: IStorageUser;
}

/**
 * Modal for editing users, restricted to admin ONLY!!
 * @param props
 * @returns
 */
export default function EditUserModal({ closeModal, isModalOpen, user }: Prop) {
  const theme = useTheme();
  const dispatch = useDispatch();
  const fullScreen = useMediaQuery(theme.breakpoints.down('md'));
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

    try {
      const data = new FormData(e.currentTarget);
      const createUserData: IStorageUser = {
        username: data.get('username')!.toString(),
        role: data.get('role')!.toString(),
        id: user.id,
      };

      await dispatch(editUser(user.id, createUserData));
      setSeverity('success');
      setMessage('User edited successfully');
      closeModal();
    } catch (error: any) {
      setSeverity('error');

      if (error.response == undefined)
        setMessage('Something went wront. Maybe you forgot something');

      setMessage(error.response.data.message);
    }
  };

  return (
    <>
      <SnackbarComponent
        open={open}
        handleClose={handleClose}
        message={message}
        severity={severity}
      />
      <Dialog
        fullScreen={fullScreen}
        open={isModalOpen}
        onClose={closeModal}
        aria-labelledby='responsive-dialog-title'
        fullWidth
      >
        <DialogActions
          sx={{ display: 'flex', justifyContent: 'space-between' }}
        >
          <DialogTitle id='responsive-dialog-title'>Edit user</DialogTitle>
          <IconButton
            edge='start'
            color='inherit'
            onClick={closeModal}
            aria-label='close'
          >
            <CloseIcon />
          </IconButton>
        </DialogActions>
        <DialogContent
          dividers
          sx={{
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center',
          }}
        >
          <Box component='form' onSubmit={handleSubmit}>
            <TextField
              margin='normal'
              required
              fullWidth
              id='username'
              label='username'
              name='username'
              autoComplete='username'
              autoFocus
              defaultValue={user.username}
              variant='outlined'
            />
            <FormControl component='fieldset' margin='dense'>
              <FormLabel component='legend'>Roles</FormLabel>
              <RadioGroup row aria-label='roles' name='row-radio-buttons-group'>
                <FormControlLabel
                  value='user'
                  control={<Radio color='primary' />}
                  label='User'
                  name='role'
                  id='role'
                />
                <FormControlLabel
                  value='admin'
                  control={<Radio color='primary' />}
                  label='Admin'
                  name='role'
                  id='role'
                />
              </RadioGroup>
            </FormControl>
            <DialogActions>
              <Button onClick={handleClick} autoFocus type='submit'>
                Confirm edit
              </Button>
            </DialogActions>
          </Box>
        </DialogContent>
      </Dialog>
    </>
  );
}
